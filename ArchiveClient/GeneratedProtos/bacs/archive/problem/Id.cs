// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: bacs/archive/problem/id.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Bacs.Archive.Problem {

  /// <summary>Holder for reflection information generated from bacs/archive/problem/id.proto</summary>
  public static partial class IdReflection {

    #region Descriptor
    /// <summary>File descriptor for bacs/archive/problem/id.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static IdReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch1iYWNzL2FyY2hpdmUvcHJvYmxlbS9pZC5wcm90bxIUYmFjcy5hcmNoaXZl",
            "LnByb2JsZW0iEwoFSWRTZXQSCgoCaWQYASADKAlCCVoHcHJvYmxlbWIGcHJv",
            "dG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Bacs.Archive.Problem.IdSet), global::Bacs.Archive.Problem.IdSet.Parser, new[]{ "Id" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class IdSet : pb::IMessage<IdSet> {
    private static readonly pb::MessageParser<IdSet> _parser = new pb::MessageParser<IdSet>(() => new IdSet());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<IdSet> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Bacs.Archive.Problem.IdReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IdSet() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IdSet(IdSet other) : this() {
      id_ = other.id_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public IdSet Clone() {
      return new IdSet(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _repeated_id_codec
        = pb::FieldCodec.ForString(10);
    private readonly pbc::RepeatedField<string> id_ = new pbc::RepeatedField<string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<string> Id {
      get { return id_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as IdSet);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(IdSet other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!id_.Equals(other.id_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= id_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      id_.WriteTo(output, _repeated_id_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += id_.CalculateSize(_repeated_id_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(IdSet other) {
      if (other == null) {
        return;
      }
      id_.Add(other.id_);
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
            id_.AddEntriesFrom(input, _repeated_id_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
