namespace PasswordManager.Models.ViewModels
{

    public class PasswordOptions
    {
        public int Length { get; set; } = 16;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeNumbers { get; set; } = true;
        public bool IncludeSymbols { get; set; } = false;
    }
}