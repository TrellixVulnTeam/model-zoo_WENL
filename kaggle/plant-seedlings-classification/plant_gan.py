import tensorflow as tf
import numpy as np
import os
import logging
from argparse import ArgumentParser

from plant_loader import PlantLoader

logging.basicConfig()
logger = logging.getLogger('plant_gan')
logger.setLevel(logging.INFO)


class Generator(object):
  def __init__(self, num_classes, image_size, noise_size=32):
    self.num_classes = num_classes
    self.noise_size = noise_size
    self.image_size = image_size

    self._setup_inputs()

  def _setup_inputs(self):
    self.input_type = tf.placeholder(dtype=tf.float32, name='input_types',
      shape=[None, self.num_classes])
    self.noise = tf.placeholder(dtype=tf.float32, name='noise',
      shape=[None, self.noise_size])

  def inference(self, inputs, noise, trainable=True):
    input_reshaped = tf.reshape(inputs, [-1, 1, 1, self.num_classes])
    noise_reshaped = tf.reshape(noise, [-1, 1, 1, self.noise_size])

    ksize = 3
    with tf.name_scope('conv1'):
      conv = tf.contrib.layers.conv2d(
        tf.concat([input_reshaped, noise_reshaped], axis=3), 64,
        stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())

    with tf.name_scope('conv2'):
      conv = tf.contrib.layers.conv2d(conv, 128, stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())

    with tf.name_scope('conv3'):
      size = self.image_size * self.image_size
      conv = tf.contrib.layers.conv2d(conv, size, stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())
      conv = tf.reshape(conv, [-1, self.image_size, self.image_size, 1])

    with tf.name_scope('output'):
      output = tf.contrib.layers.conv2d(conv, 3, stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())
    return output


class Discriminator(object):
  def __init__(self, num_classes, image_size):
    self.num_classes = num_classes
    self.image_size = image_size

    self._setup_inputs()

  def _setup_inputs(self):
    self.input_images = tf.placeholder(dtype=tf.float32, name='input_images',
      shape=[None, self.image_size, self.image_size, 3])
    self.labels = tf.placeholder(dtype=tf.float32, name='labels',
      shape=[None, self.num_classes])
    self.keep_prob = tf.placeholder(dtype=tf.float32, name='keep_prob',
      shape=[])

  def inference(self, inputs, trainable=True):
    with tf.name_scope('prenorm'):
      norm = tf.layers.batch_normalization(inputs)

    ksize = 3
    with tf.name_scope('conv1'):
      conv = tf.contrib.layers.conv2d(norm, 32, stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())

    with tf.name_scope('drop1'):
      drop = tf.nn.dropout(conv, keep_prob=self.keep_prob)

    with tf.name_scope('conv2'):
      conv = tf.contrib.layers.conv2d(drop, 32, stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())

    with tf.name_scope('pool2'):
      pool = tf.contrib.layers.max_pool2d(conv, 2)

    with tf.name_scope('conv3'):
      conv = tf.contrib.layers.conv2d(pool, 64, stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())

    with tf.name_scope('drop3'):
      drop = tf.nn.dropout(conv, keep_prob=self.keep_prob)

    with tf.name_scope('conv4'):
      conv = tf.contrib.layers.conv2d(drop, 64, stride=1, kernel_size=ksize,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())

    with tf.name_scope('pool4'):
      pool = tf.contrib.layers.max_pool2d(conv, 2)

    with tf.name_scope('fully_connected'):
      connect_shape = pool.get_shape().as_list()
      connect_size = connect_shape[1] * connect_shape[2] * connect_shape[3]
      fc = tf.contrib.layers.fully_connected(
        tf.reshape(pool, [-1, connect_size]), 256,
        trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())

    with tf.name_scope('output'):
      logits = tf.contrib.layers.fully_connected(fc, self.num_classes,
        activation_fn=None, trainable=trainable,
        weights_initializer=tf.variance_scaling_initializer())
      output = tf.nn.softmax(logits)
    return logits, output


class PlantGAN(object):
  def __init__(self, num_classes, input_size,
      glearning_rate, dlearning_rate):
    self.num_classes = num_classes
    self.input_size = input_size

    generator = Generator(self.num_classes, self.input_size)
    with tf.variable_scope('geneator_train'):
      self.generator_train_output = generator.inference(generator.input_type,
        generator.noise)
      tf.summary.image('generator_generated_image', self.generator_train_output)
    with tf.variable_scope('geneator_target'):
      self.generator_target_output = generator.inference(generator.input_type,
        generator.noise, trainable=False)
    self.generator = generator

    self.sync_generator_ops = []
    with tf.name_scope('generator_copy'):
      train_var = \
        tf.get_collection(tf.GraphKeys.GLOBAL_VARIABLES, 'generator_train')
      target_var = \
        tf.get_collection(tf.GraphKeys.GLOBAL_VARIABLES, 'generator_target')
      assert len(train_var) == len(target_var)

      for i in range(len(train_var)):
        self.sync_generator_ops.append(tf.assign(target_var[i], train_var[i]))

    discriminator = Discriminator(self.num_classes, self.input_size)
    with tf.variable_scope('discriminator_train'):
      self.train_logits, self.discriminator_train_output = \
        discriminator.inference(discriminator.input_images)
    with tf.variable_scope('discriminator_target'):
      self.target_logits, self.discriminator_target_output = \
        discriminator.inference(self.generator_train_output, trainable=False)
    self.discriminator = discriminator

    self.sync_discriminator_ops = []
    with tf.name_scope('discriminator_copy'):
      train_var = tf.get_collection(tf.GraphKeys.GLOBAL_VARIABLES,
        'discriminator_train')
      target_var = tf.get_collection(tf.GraphKeys.GLOBAL_VARIABLES,
        'discriminator_target')
      assert len(train_var) == len(target_var)

      for i in range(len(train_var)):
        self.sync_discriminator_ops.append(tf.assign(target_var[i], train_var[i]))

    with tf.name_scope('generator_loss'):
      self.gloss = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(
        logits=self.target_logits, labels=discriminator.labels))
      tf.summary.scalar('generator_loss', self.gloss)

    with tf.name_scope('discriminator_loss'):
      self.dloss = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(
        logits=self.train_logits, labels=discriminator.labels))
      tf.summary.scalar('discriminator_loss', self.dloss)

    with tf.name_scope('optimization'):
      self.glearning_rate = tf.Variable(glearning_rate, trainable=False,
        name='generator_learning_rate')
      goptimizer = tf.train.GradientDescentOptimizer(self.glearning_rate)
      self.train_generator = goptimizer.minimize(self.gloss)

      self.dlearning_rate = tf.Variable(dlearning_rate, trainable=False,
        name='discriminator_learning_rate')
      doptimizer = tf.train.GradientDescentOptimizer(self.dlearning_rate)
      self.train_discriminator = doptimizer.minimize(self.dloss)

      tf.summary.scalar('generator_learning_rate', self.glearning_rate)
      tf.summary.scalar('discriminator_learning_rate', self.dlearning_rate)

    with tf.name_scope('evaluation'):
      prediction = tf.argmax(self.discriminator_train_output, axis=1)
      answer = tf.argmax(self.discriminator.labels, axis=1)
      self.accuracy = tf.reduce_mean(tf.cast(tf.equal(prediction, answer),
        tf.float32))
      tf.summary.scalar('accuracy', self.accuracy)

    with tf.name_scope('summary'):
      self.summary = tf.summary.merge_all()

  def prepare_folder(self):
    index = 0
    folder = 'gan-%s_%d' % (self.inference, index)
    while os.path.isdir(folder):
      index += 1
      folder = 'gan-%s_%d' % (self.inference, index)
    os.mkdir(folder)
    return folder

  def train(self, args):
    loader = PlantLoader(args.dbname)
    loader.load_data()

    # prepare data
    if args.load_all:
      training_data = loader.get_data()
      training_labels = loader.get_label()
    else:
      training_data = loader.get_training_data()
      training_labels = loader.get_training_labels()

    data_size = len(training_data)

    validation_data = loader.get_validation_data()
    validation_labels = loader.get_validation_labels()

    # prepare saver
    if args.saving:
      folder = self.prepare_folder()
      checkpoint = os.path.join(folder, 'gan')

      saver = tf.train.Saver()
      temp_summary = os.path.join('/tmp', folder)
      if not os.path.isdir(temp_summary):
        os.mkdir(temp_summary)
      summary_writer = tf.summary.FileWriter(temp_summary,
        tf.get_default_graph())

    config = tf.ConfigProto()
    config.gpu_options.allow_growth = True
    with tf.Session(config=config) as sess:
      logger.info('initializing variables...')
      sess.run(tf.global_variables_initializer())

      for epoch in range(args.max_epochs):
        offset = epoch % (data_size - args.batch_size)
        data_batch = training_data[offset:offset+args.batch_size, :]
        label_batch = training_labels[offset:offset+args.batch_size, :]

        # generate images
        sess.run(self.sync_generator_ops)
        noise = np.random.normal(0.0, 1.0,
          size=[args.batch_size, self.noise_size])
        generated_images = sess.run(self.generator_target_output, feed_dict={
          self.generator.input_type: training_labels,
          self.generator.noise: noise,
        })
        generated_labels = np.zeros(shape=[args.batch_size,
          self.generator.num_classes])

        combined_data = np.concatenate([data_batch, generated_images], axis=0)
        combined_label = np.concatenate([label_batch, generated_labels], axis=0)

        if epoch % args.display_epoches == 0:
          gloss = sess.run(self.gloss, feed_dict={
            self.generator.noise: np.random.normal(0.0, 1.0,
              size=[args.batch_size, self.noise_size]),
            self.generator.input_type: label_batch,
            self.discriminator.labels: label_batch,
            self.discriminator.keep_prob: 1.0,
          })

          dloss, accuracy = sess.run([self.dloss, self.accuracy], feed_dict={
            self.discriminator.input_images: combined_data,
            self.discriminator.labels: combined_label,
            self.discriminator.keep_prob: 1.0,
          })

          valid_dloss, valid_accuracy = sess.run([self.dloss, self.accuracy],
            feed_dict={
              self.discriminator.input_images: validation_data,
              self.discriminator.labels: validation_labels,
              self.discriminator.keep_prob: 1.0,
            })

          logger.info('%d. gloss: %f, dloss: %f, classification: %f',
            epoch, gloss, dloss, accuracy)
          logger.info('validation dloss: %f, classification: %f',
            valid_dloss, valid_accuracy)

        # train discriminator
        sess.run(self.train_discriminator, feed_dict={
          self.discriminator.input_images: combined_data,
          self.discriminator.labels: combined_label,
          self.discriminator.keep_prob: args.keep_prob,
        })

        # train generator
        if epoch % args.tau == 0:
          sess.run(self.sync_discriminator_ops)
          noise = np.random.normal(0.0, 1.0,
            size=[args.batch_size, self.noise_size])
          sess.run(self.train_generator, feed_dict={
            self.generator.input_type: label_batch,
            self.generator.noise: noise,
            self.discriminator.keep_prob: 1.0,
            self.discriminator.labels: label_batch,
          })

        if epoch % args.save_epoches == 0 and epoch != 0 and args.saving:
          saver.save(sess, checkpoint, global_step=epoch)

        if epoch % args.summary_epoches == 0 and epoch != 0 and args.saving:
          summary = sess.run(self.summary, feed_dict={
            self.generator.input_type: label_batch,
            self.generator.noise: noise,
            self.discriminator.input_images: data_batch,
            self.discriminator.labels: label_batch,
            self.discriminator.keep_prob: args.keep_prob,
          })
          summary_writer.add_summary(summary, global_step=epoch)


def main():
  parser = ArgumentParser()
  parser.add_argument('--dbname', dest='dbname', default='plants.sqlite3',
    type=str, help='dbname to load data for training')

  parser.add_argument('--glearning-rate', dest='glearning_rate',
    default=1e-3, type=float, help='generator learning rate')
  parser.add_argument('--dlearning-rate', dest='dlearning_rate',
    default=1e-3, type=float, help='discriminator learning rate')
  parser.add_argument('--tau', dest='tau',
    default=10, type=int, help='the frequency for updating generator')
  parser.add_argument('--max-epoches', dest='max_epoches', default=60000,
    type=int, help='max epoches to train model')
  parser.add_argument('--display-epoches', dest='display_epoches', default=50,
    type=int, help='epoches to evaluation')
  parser.add_argument('--save-epoches', dest='save_epoches', default=1000,
    type=int, help='epoches to save model')
  parser.add_argument('--summary-epoches', dest='summary_epoches', default=10,
    type=int, help='epoch to save summary')
  parser.add_argument('--batch-size', dest='batch_size', default=64,
    type=int, help='batch size to train model')
  parser.add_argument('--saving', dest='saving', default=False,
    type=bool, help='rather to save model or not')
  parser.add_argument('--keep-prob', dest='keep_prob', default=0.8,
    type=float, help='keep probability for dropout')
  parser.add_argument('--decay-epoch', dest='decay_epoch', default=10000,
    type=int, help='epoches to decay learning rate')

  args = parser.parse_args()

  PlantGAN(12, 32, args.glearning_rate, args.dlearning_rate)



if __name__ == '__main__':
  main()