using System.Collections.Generic;
using System.Threading.Tasks;
using Bacs.Archive.Problem;

namespace ArchiveClient
{
    public interface IArchiveClient
    {
        StatusResult Rename(string from, string to);

        Task<byte[]> DownloadAsync(IFormat format, params string[] ids);
        byte[] Download(IFormat format, params string[] ids);
        Task UploadAsync(IFormat format, IEnumerable<byte> bytes);
        void Upload(IFormat format, IEnumerable<byte> bytes);

        IEnumerable<string> Existing(params string[] ids);
        IEnumerable<string> ExistingAll();

        Dictionary<string, StatusResult> Status(params string[] ids);
        Dictionary<string, StatusResult> StatusAll();

        Dictionary<string, ImportResult> ImportResult(params string[] ids);
        Dictionary<string, StatusResult> Import(params string[] ids);
        Dictionary<string, StatusResult> ImportAll();

        IEnumerable<string> WithFlag(params string[] ids);
        IEnumerable<string> WithFlagAll();

        Dictionary<string, StatusResult> SetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags, params string[] ids);
        Dictionary<string, StatusResult> ClearFlags(params string[] ids);
        Dictionary<string, StatusResult> UnsetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags, params string[] ids);
    }
}