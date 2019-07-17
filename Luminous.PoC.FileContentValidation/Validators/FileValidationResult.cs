namespace Luminous.PoC.FileContentValidation.Validators
{
    public struct FileValidationResult
    {
        public FileValidationResult(string fileName, bool isValid)
        {
            FileName = fileName;
            IsValid = isValid;
        }

        public string FileName { get; }

        public bool IsValid { get; }
    }
}