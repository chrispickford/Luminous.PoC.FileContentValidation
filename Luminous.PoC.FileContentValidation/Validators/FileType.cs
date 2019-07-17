namespace Luminous.PoC.FileContentValidation.Validators
{
    internal struct FileType
    {
        public FileType(byte[] header, int headerOffset = 0)
        {
            Header = header;
            HeaderOffset = headerOffset;
        }
        public byte[] Header { get; }
        public int HeaderOffset { get; }
        
        public static readonly FileType JPEG = new FileType(new byte[] { 0xFF, 0xD8, 0xFF });
        public static readonly FileType PDF = new FileType(new byte[] { 0x25, 0x50, 0x44, 0x46 });
        public static readonly FileType PNG = new FileType(new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A });
    }
}