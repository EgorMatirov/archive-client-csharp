using System;
using System.IO;
using System.Linq;
using Bacs.Archive;
using Bacs.Archive.Problem;
using Bacs.Utility;
using CommandLine;
using Demo.Options;
using Google.Protobuf;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core.Utils;

namespace Demo
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<ExistingAllOptions, DownloadOptions, UploadOptions>(args)
                .MapResult(
                    (ExistingAllOptions options) => ExistingAll(options),
                    (DownloadOptions options) => Download(options),
                    (UploadOptions options) => Upload(options),
                    errs => 1
                );
        }

        private static int Upload(UploadOptions options)
        {
            var client = CreateClient(options);
            var stream = client.Upload();
            var bytes = File.ReadAllBytes(options.Source)
                .Batch(1024 * 1024)
                .Select(x => x.ToArray())
                .ToArray();
            stream.RequestStream.WriteAllAsync(
                bytes.Select(x => new Chunk
                {
                    Data = ByteString.CopyFrom(x),
                    Format = new Archiver { Format = "gz", Type = "tar" }
                })
            ).Wait();
            return 0;
        }

        private static int Download(DownloadOptions options)
        {
            var client = CreateClient(options);
            var r = client.Download(new DownloadRequest
            {
                Format = new Archiver { Format = "gz", Type = "tar" },
                Ids = new IdSet { Id = { options.Id } }
            });
            var bytes = r.ResponseStream
                .ToListAsync()
                .Result
                .SelectMany(x => x.Data.ToByteArray())
                .ToArray();
            File.WriteAllBytes(options.Target, bytes);
            return 0;
        }

        private static int ExistingAll(ConnectionOptions options)
        {
            var client = CreateClient(options);
            client
                .ExistingAll(new Empty())
                .Id
                .ToList()
                .ForEach(Console.WriteLine);
            return 0;
        }

        private static Archive.ArchiveClient CreateClient(ConnectionOptions options)
        {
            var clientcert = File.ReadAllText(options.ClientCertificate);
            var clientkey = File.ReadAllText(options.ClientKey);
            var cacert = File.ReadAllText(options.CaCertificate);
            var ssl = new SslCredentials(cacert, new KeyCertificatePair(clientcert, clientkey));
            var channel = new Channel(options.Host, ssl);
            return new Archive.ArchiveClient(channel);
        }
    }
}
