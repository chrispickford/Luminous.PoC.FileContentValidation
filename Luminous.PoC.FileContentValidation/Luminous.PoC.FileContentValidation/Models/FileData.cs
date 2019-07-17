namespace Luminous.PoC.FileContentValidation.Models
{
    public class FileData
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public long? SizeBytes { get; set; }
    }
}