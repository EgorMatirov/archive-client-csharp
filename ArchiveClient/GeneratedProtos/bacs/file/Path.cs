// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: bacs/file/path.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Bacs.File {

  /// <summary>Holder for reflection information generated from bacs/file/path.proto</summary>
  public static partial class PathReflection {

    #region Descriptor
    /// <summary>File descriptor for bacs/file/path.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PathReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRiYWNzL2ZpbGUvcGF0aC5wcm90bxIJYmFjcy5maWxlIiUKBFBhdGgSDAoE",
            "cm9vdBgBIAEoCRIPCgdlbGVtZW50GAIgAygJQgZaBGZpbGViBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Bacs.File.Path), global::Bacs.File.Path.Parser, new[]{ "Root", "Element" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// / Filesystem path.
  /// </summary>
  public sealed partial class Path : pb::IMessage<Path> {
    private static readonly pb::MessageParser<Path> _parser = new pb::MessageParser<Path>(() => new Path());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Path> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Bacs.File.PathReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Path() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Path(Path other) : this() {
      root_ = other.root_;
      element_ = other.element_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Path Clone() {
      return new Path(this);
    }

    /// <summary>Field number for the "root" field.</summary>
    public const int RootFieldNumber = 1;
    private string root_ = "";
    /// <summary>
    /// / If specified, path is absolute, otherwise -- relative.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Root {
      get { return root_; }
      set {
        root_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "element" field.</summary>
    public const int ElementFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _repeated_element_codec
        = pb::FieldCodec.ForString(18);
    private readonly pbc::RepeatedField<string> element_ = new pbc::RepeatedField<string>();
    /// <summary>
    /// / Path elements, will be concatenated using OS-specific delimiter.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Element {
      get { return element_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Path);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Path other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Root != other.Root) return false;
      if(!element_.Equals(other.element_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Root.Length != 0) hash ^= Root.GetHashCode();
      hash ^= element_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Root.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Root);
      }
      element_.WriteTo(output, _repeated_element_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Root.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Root);
      }
      size += element_.CalculateSize(_repeated_element_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Path other) {
      if (other == null) {
        return;
      }
      if (other.Root.Length != 0) {
        Root = other.Root;
      }
      element_.Add(other.element_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Root = input.ReadString();
            break;
          }
          case 18: {
            element_.AddEntriesFrom(input, _repeated_element_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
