using System.Collections.Generic;

namespace ArchiveClient
{
    public class GzFormat : IFormat
    {
        public enum GzFormatType
        {
            Tar
        }

        private static Dictionary<GzFormatType, string> typeValues =
            new Dictionary<GzFormatType, string>
            {
                {GzFormatType.Tar, "tar"}
            };

        public GzFormat(GzFormatType type)
        {
            Type = typeValues[type];
        }

        public string Format => "gz";
        public string Type { get; }
    }
}