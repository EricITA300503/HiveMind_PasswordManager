using PasswordManager.Models.ViewModels;
using System;
using System.Linq;
using System.Text;

namespace PasswordManager.Services
{
    public class PasswordService : IPasswordService
    {
        public string GeneratePassword(PasswordOptions options)
        {
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string symbols = "!@#$%^&*()_-+=[{]};:<>|./?";

            var charSet = new StringBuilder(lowercase);
            if (options.IncludeUppercase) charSet.Append(uppercase);
            if (options.IncludeNumbers) charSet.Append(numbers);
            if (options.IncludeSymbols) charSet.Append(symbols);

            var random = new Random();
            var password = new char[options.Length];
            var setAsString = charSet.ToString();

            for (int i = 0; i < options.Length; i++)
            {
                password[i] = setAsString[random.Next(setAsString.Length)];
            }

            return new string(password);
        }

        public StrengthResult EvaluateStrength(string password)
        {
            return new StrengthResult
            {
                Score = password.Length >= 12 ? 4 : 2,
                Label = password.Length >= 12 ? "Strong" : "Weak"
            };
        }
    }
}