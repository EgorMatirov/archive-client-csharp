using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bacs.Archive;
using Bacs.Archive.Problem;
using Bacs.Utility;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core.Utils;

namespace ArchiveClient
{
    public class ArchiveClient : IArchiveClient
    {
        private readonly Archive.ArchiveClient _innerClient;

        public ArchiveClient(Archive.ArchiveClient innerClient)
        {
            _innerClient = innerClient;
        }

        public async Task<byte[]> DownloadAsync(IFormat format, params string[] ids)
        {
            var r = _innerClient.Download(new DownloadRequest
            {
                Format = new Archiver {Format = format.Format, Type = format.Type},
                Ids = GrpcExtensions.IdSetFromIds(ids)
            });
            var list = await r.ResponseStream.ToListAsync();
            return list.SelectMany(x => x.Data.ToByteArray()).ToArray();
        }

        public byte[] Download(IFormat format, params string[] ids)
        {
            var r = _innerClient.Download(new DownloadRequest
            {
                Format = new Archiver {Format = format.Format, Type = format.Type},
                Ids = GrpcExtensions.IdSetFromIds(ids)
            });
            var list = r.ResponseStream.ToListAsync().Result;
            return list.SelectMany(x => x.Data.ToByteArray()).ToArray();
        }

        public async Task UploadAsync(IFormat format, IEnumerable<byte> bytes)
        {
            var stream = _innerClient.Upload();
            var chunks = bytes
                .Batch(1024*1024)
                .Select(x => x.ToArray());
            await stream.RequestStream.WriteAllAsync(
                chunks.Select(x => new Chunk
                {
                    Data = ByteString.CopyFrom(x),
                    Format = new Archiver {Format = format.Format, Type = format.Type}
                })
            );
        }

        public void Upload(IFormat format, IEnumerable<byte> bytes)
        {
            var stream = _innerClient.Upload();
            var chunks = bytes
                .Batch(1024*1024)
                .Select(x => x.ToArray());
            stream.RequestStream.WriteAllAsync(
                chunks.Select(x => new Chunk
                {
                    Data = ByteString.CopyFrom(x),
                    Format = new Archiver {Format = format.Format, Type = format.Type}
                })
            ).Wait();
        }

        public StatusResult Rename(string from, string to)
        {
            return _innerClient.Rename(new RenameRequest {From = from, To = to});
        }

        public IEnumerable<string> Existing(params string[] ids)
        {
            return _innerClient
                .Existing(GrpcExtensions.IdSetFromIds(ids))
                .Id
                .AsEnumerable();
        }

        public IEnumerable<string> ExistingAll()
        {
            return _innerClient
                .ExistingAll(new Empty())
                .Id
                .AsEnumerable();
        }

        public Dictionary<string, StatusResult> Status(params string[] ids)
        {
            return _innerClient
                .Status(GrpcExtensions.IdSetFromIds(ids))
                .Entry
                .ToDictionary();
        }

        public Dictionary<string, StatusResult> StatusAll()
        {
            return _innerClient
                .StatusAll(new Empty())
                .Entry
                .ToDictionary();
        }

        public Dictionary<string, ImportResult> ImportResult(params string[] ids)
        {
            return _innerClient
                .ImportResult(GrpcExtensions.IdSetFromIds(ids))
                .Entry
                .ToDictionary();
        }

        public Dictionary<string, StatusResult> Import(params string[] ids)
        {
            return _innerClient
                .Import(GrpcExtensions.IdSetFromIds(ids))
                .Entry
                .ToDictionary();
        }

        public Dictionary<string, StatusResult> ImportAll()
        {
            return _innerClient
                .ImportAll(new Empty())
                .Entry
                .ToDictionary();
        }

        // Flag API is not stable. Not intended for public usage. (from proto)
        public IEnumerable<string> WithFlag(params string[] ids)
        {
            return _innerClient
                .WithFlag(GrpcExtensions.IdSetFromIds(ids))
                .Id
                .AsEnumerable();
        }

        public IEnumerable<string> WithFlagAll()
        {
            return _innerClient
                .WithFlagAll(new Empty())
                .Id
                .AsEnumerable();
        }

        public Dictionary<string, StatusResult> SetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags,
            params string[] ids)
        {
            return ChangeFlagsInner(x => _innerClient.SetFlags(x), reservedFlags, customFlags, ids);
        }

        public Dictionary<string, StatusResult> UnsetFlags(Flag.Types.Reserved[] reservedFlags, string[] customFlags,
            params string[] ids)
        {
            return ChangeFlagsInner(x => _innerClient.UnsetFlags(x), reservedFlags, customFlags, ids);
        }

        public Dictionary<string, StatusResult> ClearFlags(params string[] ids)
        {
            return _innerClient
                .ClearFlags(GrpcExtensions.IdSetFromIds(ids))
                .Entry
                .ToDictionary();
        }

        private static Dictionary<string, StatusResult> ChangeFlagsInner(
            Func<ChangeFlagsRequest, StatusMap> changeAction,
            IEnumerable<Flag.Types.Reserved> reservedFlags,
            IEnumerable<string> customFlags,
            string[] ids)
        {
            var flags = reservedFlags
                .Select(x => new Flag {Reserved = x})
                .Concat(customFlags.Select(x => new Flag {Custom = x}));

            return changeAction(
                    new ChangeFlagsRequest
                    {
                        Ids = GrpcExtensions.IdSetFromIds(ids),
                        Flag = new FlagSet
                        {
                            Flag = {flags}
                        }
                    }
                )
                .Entry
                .ToDictionary();
        }
    }
}