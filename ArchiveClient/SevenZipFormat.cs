using System.Collections.Generic;

namespace ArchiveClient
{
    public class SevenZipFormat : IFormat
    {
        public enum SevenZipFormatType
        {
            Auto,
            SevenZip,
            Zip,
            Tar
        }

        private static readonly Dictionary<SevenZipFormatType, string> FormatValues =
            new Dictionary<SevenZipFormatType, string>
            {
                {SevenZipFormatType.Auto, ""},
                {SevenZipFormatType.SevenZip, "7z"},
                {SevenZipFormatType.Zip, "zip"},
                {SevenZipFormatType.Tar, "tar"},
            };

        public SevenZipFormat(SevenZipFormatType format)
        {
            Format = FormatValues[format];
        }

        public string Type => "7z";
        public string Format { get; }
    }
}
