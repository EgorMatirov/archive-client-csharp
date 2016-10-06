// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: bacs/problem/result.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Bacs.Problem {

  /// <summary>Holder for reflection information generated from bacs/problem/result.proto</summary>
  public static partial class ResultReflection {

    #region Descriptor
    /// <summary>File descriptor for bacs/problem/result.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ResultReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChliYWNzL3Byb2JsZW0vcmVzdWx0LnByb3RvEgxiYWNzLnByb2JsZW0iaQoM",
            "U3lzdGVtUmVzdWx0EjEKBnN0YXR1cxgBIAEoDjIhLmJhY3MucHJvYmxlbS5T",
            "eXN0ZW1SZXN1bHQuU3RhdHVzIiYKBlN0YXR1cxIGCgJPSxAAEhQKEElOVkFM",
            "SURfUkVWSVNJT04QAUIJWgdwcm9ibGVtYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Bacs.Problem.SystemResult), global::Bacs.Problem.SystemResult.Parser, new[]{ "Status" }, null, new[]{ typeof(global::Bacs.Problem.SystemResult.Types.Status) }, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class SystemResult : pb::IMessage<SystemResult> {
    private static readonly pb::MessageParser<SystemResult> _parser = new pb::MessageParser<SystemResult>(() => new SystemResult());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<SystemResult> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Bacs.Problem.ResultReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SystemResult() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SystemResult(SystemResult other) : this() {
      status_ = other.status_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public SystemResult Clone() {
      return new SystemResult(this);
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 1;
    private global::Bacs.Problem.SystemResult.Types.Status status_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Bacs.Problem.SystemResult.Types.Status Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as SystemResult);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(SystemResult other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Status != other.Status) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Status != 0) hash ^= Status.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Status != 0) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Status);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Status != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Status);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(SystemResult other) {
      if (other == null) {
        return;
      }
      if (other.Status != 0) {
        Status = other.Status;
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
            status_ = (global::Bacs.Problem.SystemResult.Types.Status) input.ReadEnum();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the SystemResult message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum Status {
        [pbr::OriginalName("OK")] Ok = 0,
        [pbr::OriginalName("INVALID_REVISION")] InvalidRevision = 1,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code