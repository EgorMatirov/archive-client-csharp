using System;
using Bacs.Archive;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Demo
{
    internal class Program
    {
        private static void Main()
        {
            const string host = "hostname:port";
            var credentials = new SslCredentials("");
            var client = new Archive.ArchiveClient(new Channel(host, credentials));
            var result = client.ExistingAll(new Empty());
            foreach (var id in result.Id)
            {
                Console.WriteLine(id);
            }
            Console.ReadLine();
        }
    }
}
