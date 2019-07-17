using System;
using System.IO;
using System.Runtime.Serialization;

namespace Luminous.PoC.FileContentValidation.Models
{
    [Serializable]
    public sealed class FileData : ISerializable
    {
        public string FileName { get; }
        public Stream ContentStream { get; }
        public string MimeType { get; }
        public long? SizeBytes { get; }

        public FileData(string fileName, Stream contentStream, string mimeType = null, long? sizeBytes = null)
        {
            FileName = fileName;
            ContentStream = contentStream;
            MimeType = mimeType;
            SizeBytes = sizeBytes;
        }

        private FileData(SerializationInfo info, StreamingContext context)
        {
            FileName = info.GetValue(nameof(FileName), typeof(string)) as string;
            MimeType = info.GetValue(nameof(MimeType), typeof(string)) as string;
            SizeBytes = info.GetValue(nameof(SizeBytes), typeof(long?)) as long?;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(FileName), FileName);
            info.AddValue(nameof(MimeType), MimeType);
            info.AddValue(nameof(SizeBytes), SizeBytes);
        }
    }
}