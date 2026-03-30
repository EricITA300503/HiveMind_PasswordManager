using PasswordManager.Models.ViewModels;

namespace PasswordManager.Services
{
    public interface IPasswordService
    {
        string GeneratePassword(PasswordOptions options);
        StrengthResult EvaluateStrength(string password);
    }
}