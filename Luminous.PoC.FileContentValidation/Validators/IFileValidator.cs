using Luminous.PoC.FileContentValidation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Luminous.PoC.FileContentValidation.Validators
{
    public interface IFileValidator
    {
        Task<FileValidationResult> Validate(FileData fileData);
        Task<IEnumerable<FileValidationResult>> Validate(IEnumerable<FileData> fileData);
    }
}