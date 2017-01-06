using System;
using System.IO;
using System.Linq;
using ArchiveClient;
using CommandLine;
using Demo.Options;

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
            var statusMap = client.Upload(SevenZipArchive.ZipFormat, File.ReadAllBytes(options.Source));
            foreach (var keyValuePair in statusMap)
            {
                Console.WriteLine($"Key: {keyValuePair.Key}; value: {keyValuePair.Value}");
            }
            return 0;
        }

        private static int Download(DownloadOptions options)
        {
            var client = CreateClient(options);
            var bytes = client.Download(SevenZipArchive.ZipFormat, options.Id);
            File.WriteAllBytes(options.Target, bytes);
            return 0;
        }

        private static int ExistingAll(ConnectionOptions options)
        {
            var client = CreateClient(options);
            client
                .ExistingAll()
                .ToList()
                .ForEach(Console.WriteLine);
            return 0;
        }

        private static IArchiveClient CreateClient(ConnectionOptions options)
        {
            return ArchiveClientFactory.Create(
                options.Host,
                options.Port,
                options.ClientCertificate,
                options.ClientKey,
                options.CaCertificate);
        }
    }
}
