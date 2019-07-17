using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Luminous.PoC.FileContentValidation.Models;

namespace Luminous.PoC.FileContentValidation.Validators
{
    public sealed class FileContentValidator : IFileValidator
    {
        public async Task<FileValidationResult> Validate(FileData fileData)
        {
            if (await IsType(fileData, FileType.PDF))
            {
                return new FileValidationResult(fileData.FileName, true);
            }
            
            return new FileValidationResult(fileData.FileName, false);
        }

        public async Task<IEnumerable<FileValidationResult>> Validate(IEnumerable<FileData> fileData)
        {
            var validateTasks = fileData.Select(Validate);
            return await Task.WhenAll(validateTasks);
        }

        private static async Task<bool> IsType(FileData fileData, FileType fileType)
        {
            var header = await ReadFileHeader(fileData.ContentStream, fileType.Header.Length, fileType.HeaderOffset);
            return header.SequenceEqual(fileType.Header);
        }

        private static async Task<byte[]> ReadFileHeader(Stream stream, int headerSize, int headerOffset = 0)
        {
            var header = new byte[headerSize];
            
            await stream.ReadAsync(header, headerOffset, headerSize);
            stream.Seek(0, SeekOrigin.Begin);

            return header;
        }
    }
}