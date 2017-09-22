// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: rotational_invariance_v3.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace RI {

  /// <summary>Holder for reflection information generated from rotational_invariance_v3.proto</summary>
  public static partial class RotationalInvarianceV3Reflection {

    #region Descriptor
    /// <summary>File descriptor for rotational_invariance_v3.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RotationalInvarianceV3Reflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch5yb3RhdGlvbmFsX2ludmFyaWFuY2VfdjMucHJvdG8SAlJJIgYKBE51bGwi",
            "MgoEUmVjdBIJCgF4GAEgASgCEgkKAXkYAiABKAISCQoBdxgDIAEoAhIJCgFo",
            "GAQgASgCIkUKBUltYWdlEg0KBXdpZHRoGAEgASgFEg4KBmhlaWdodBgCIAEo",
            "BRIPCgdjaGFubmVsGAMgASgFEgwKBGRhdGEYBCABKAwiLwoDUk9JEg8KB251",
            "bV9yb2kYASABKAUSFwoFcmVjdHMYAiABKAsyCC5SSS5SZWN0MiwKClJPSVNl",
            "cnZpY2USHgoGR2V0Uk9JEgkuUkkuSW1hZ2UaBy5SSS5ST0kiADIxCgxJbWFn",
            "ZVNlcnZpY2USIQoIR2V0SW1hZ2USCC5SSS5OdWxsGgkuUkkuSW1hZ2UiAGIG",
            "cHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::RI.Null), global::RI.Null.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RI.Rect), global::RI.Rect.Parser, new[]{ "X", "Y", "W", "H" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RI.Image), global::RI.Image.Parser, new[]{ "Width", "Height", "Channel", "Data" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::RI.ROI), global::RI.ROI.Parser, new[]{ "NumRoi", "Rects" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Null : pb::IMessage<Null> {
    private static readonly pb::MessageParser<Null> _parser = new pb::MessageParser<Null>(() => new Null());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Null> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::RI.RotationalInvarianceV3Reflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Null() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Null(Null other) : this() {
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Null Clone() {
      return new Null(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Null);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Null other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Null other) {
      if (other == null) {
        return;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
        }
      }
    }

  }

  public sealed partial class Rect : pb::IMessage<Rect> {
    private static readonly pb::MessageParser<Rect> _parser = new pb::MessageParser<Rect>(() => new Rect());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Rect> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::RI.RotationalInvarianceV3Reflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Rect() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Rect(Rect other) : this() {
      x_ = other.x_;
      y_ = other.y_;
      w_ = other.w_;
      h_ = other.h_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Rect Clone() {
      return new Rect(this);
    }

    /// <summary>Field number for the "x" field.</summary>
    public const int XFieldNumber = 1;
    private float x_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float X {
      get { return x_; }
      set {
        x_ = value;
      }
    }

    /// <summary>Field number for the "y" field.</summary>
    public const int YFieldNumber = 2;
    private float y_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Y {
      get { return y_; }
      set {
        y_ = value;
      }
    }

    /// <summary>Field number for the "w" field.</summary>
    public const int WFieldNumber = 3;
    private float w_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float W {
      get { return w_; }
      set {
        w_ = value;
      }
    }

    /// <summary>Field number for the "h" field.</summary>
    public const int HFieldNumber = 4;
    private float h_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float H {
      get { return h_; }
      set {
        h_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Rect);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Rect other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (X != other.X) return false;
      if (Y != other.Y) return false;
      if (W != other.W) return false;
      if (H != other.H) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (X != 0F) hash ^= X.GetHashCode();
      if (Y != 0F) hash ^= Y.GetHashCode();
      if (W != 0F) hash ^= W.GetHashCode();
      if (H != 0F) hash ^= H.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (X != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(X);
      }
      if (Y != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Y);
      }
      if (W != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(W);
      }
      if (H != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(H);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (X != 0F) {
        size += 1 + 4;
      }
      if (Y != 0F) {
        size += 1 + 4;
      }
      if (W != 0F) {
        size += 1 + 4;
      }
      if (H != 0F) {
        size += 1 + 4;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Rect other) {
      if (other == null) {
        return;
      }
      if (other.X != 0F) {
        X = other.X;
      }
      if (other.Y != 0F) {
        Y = other.Y;
      }
      if (other.W != 0F) {
        W = other.W;
      }
      if (other.H != 0F) {
        H = other.H;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 13: {
            X = input.ReadFloat();
            break;
          }
          case 21: {
            Y = input.ReadFloat();
            break;
          }
          case 29: {
            W = input.ReadFloat();
            break;
          }
          case 37: {
            H = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  public sealed partial class Image : pb::IMessage<Image> {
    private static readonly pb::MessageParser<Image> _parser = new pb::MessageParser<Image>(() => new Image());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Image> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::RI.RotationalInvarianceV3Reflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Image() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Image(Image other) : this() {
      width_ = other.width_;
      height_ = other.height_;
      channel_ = other.channel_;
      data_ = other.data_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Image Clone() {
      return new Image(this);
    }

    /// <summary>Field number for the "width" field.</summary>
    public const int WidthFieldNumber = 1;
    private int width_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Width {
      get { return width_; }
      set {
        width_ = value;
      }
    }

    /// <summary>Field number for the "height" field.</summary>
    public const int HeightFieldNumber = 2;
    private int height_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Height {
      get { return height_; }
      set {
        height_ = value;
      }
    }

    /// <summary>Field number for the "channel" field.</summary>
    public const int ChannelFieldNumber = 3;
    private int channel_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Channel {
      get { return channel_; }
      set {
        channel_ = value;
      }
    }

    /// <summary>Field number for the "data" field.</summary>
    public const int DataFieldNumber = 4;
    private pb::ByteString data_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Data {
      get { return data_; }
      set {
        data_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Image);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Image other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Width != other.Width) return false;
      if (Height != other.Height) return false;
      if (Channel != other.Channel) return false;
      if (Data != other.Data) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Width != 0) hash ^= Width.GetHashCode();
      if (Height != 0) hash ^= Height.GetHashCode();
      if (Channel != 0) hash ^= Channel.GetHashCode();
      if (Data.Length != 0) hash ^= Data.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Width != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Width);
      }
      if (Height != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Height);
      }
      if (Channel != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Channel);
      }
      if (Data.Length != 0) {
        output.WriteRawTag(34);
        output.WriteBytes(Data);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Width != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Width);
      }
      if (Height != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Height);
      }
      if (Channel != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Channel);
      }
      if (Data.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Data);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Image other) {
      if (other == null) {
        return;
      }
      if (other.Width != 0) {
        Width = other.Width;
      }
      if (other.Height != 0) {
        Height = other.Height;
      }
      if (other.Channel != 0) {
        Channel = other.Channel;
      }
      if (other.Data.Length != 0) {
        Data = other.Data;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Width = input.ReadInt32();
            break;
          }
          case 16: {
            Height = input.ReadInt32();
            break;
          }
          case 24: {
            Channel = input.ReadInt32();
            break;
          }
          case 34: {
            Data = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ROI : pb::IMessage<ROI> {
    private static readonly pb::MessageParser<ROI> _parser = new pb::MessageParser<ROI>(() => new ROI());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ROI> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::RI.RotationalInvarianceV3Reflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ROI() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ROI(ROI other) : this() {
      numRoi_ = other.numRoi_;
      Rects = other.rects_ != null ? other.Rects.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ROI Clone() {
      return new ROI(this);
    }

    /// <summary>Field number for the "num_roi" field.</summary>
    public const int NumRoiFieldNumber = 1;
    private int numRoi_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int NumRoi {
      get { return numRoi_; }
      set {
        numRoi_ = value;
      }
    }

    /// <summary>Field number for the "rects" field.</summary>
    public const int RectsFieldNumber = 2;
    private global::RI.Rect rects_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::RI.Rect Rects {
      get { return rects_; }
      set {
        rects_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ROI);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ROI other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (NumRoi != other.NumRoi) return false;
      if (!object.Equals(Rects, other.Rects)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (NumRoi != 0) hash ^= NumRoi.GetHashCode();
      if (rects_ != null) hash ^= Rects.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (NumRoi != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(NumRoi);
      }
      if (rects_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Rects);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (NumRoi != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(NumRoi);
      }
      if (rects_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Rects);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ROI other) {
      if (other == null) {
        return;
      }
      if (other.NumRoi != 0) {
        NumRoi = other.NumRoi;
      }
      if (other.rects_ != null) {
        if (rects_ == null) {
          rects_ = new global::RI.Rect();
        }
        Rects.MergeFrom(other.Rects);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            NumRoi = input.ReadInt32();
            break;
          }
          case 18: {
            if (rects_ == null) {
              rects_ = new global::RI.Rect();
            }
            input.ReadMessage(rects_);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code