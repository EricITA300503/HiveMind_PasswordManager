// ============================================================
// File:    PasswordOptions.cs
// Author:  Benjamin Mathies
// Purpose: ViewModel for password generator options. Sent
//          as JSON body to the generate API endpoint.
// ============================================================
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