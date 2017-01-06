using System.Collections.Generic;

namespace ArchiveClient
{
    public class TarFormat : IFormat
    {
        public enum TarFormatType
        {
            Tar,
            GZip,
            BZip2,
            Xz,
            Lzma,
            Lzop
        }

        private static readonly Dictionary<TarFormatType, string> FormatValues =
            new Dictionary<TarFormatType, string>
            {
                {TarFormatType.Tar, ""},
                {TarFormatType.GZip, "gzip"},
                {TarFormatType.BZip2, "bzip2"},
                {TarFormatType.Xz, "xz"},
                {TarFormatType.Lzma, "lzma"},
                {TarFormatType.Lzop, "lzop"}
            };

        public TarFormat(TarFormatType format)
        {
            Format = FormatValues[format];
        }

        public string Type => "tar";
        public string Format { get; }
    }
}