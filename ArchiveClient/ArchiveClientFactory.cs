using System.IO;
using Bacs.Archive;
using Grpc.Core;

namespace ArchiveClient
{
    public static class ArchiveClientFactory
    {
        public static IArchiveClient Create(string host, int port, string clientCertificatePath, string clientKeyPath, string caCertificatePath)
        {
            var clientcert = File.ReadAllText(clientCertificatePath);
            var clientkey = File.ReadAllText(clientKeyPath);
            var cacert = File.ReadAllText(caCertificatePath);
            var ssl = new SslCredentials(cacert, new KeyCertificatePair(clientcert, clientkey));
            var channel = new Channel($"{host}:{port}", ssl);
            var innerClient = new Archive.ArchiveClient(channel);
            return new ArchiveClient(innerClient);
        }
    }
}