// ============================================================
// File:    IPasswordService.cs
// Author:  Benjamin Mathies
// Purpose: Contract interface for password generation and
//          strength checking.
// ============================================================
using PasswordManager.Models.ViewModels;

namespace PasswordManager.Services
{
    public interface IPasswordService
    {
        string GeneratePassword(PasswordOptions options);
        StrengthResult EvaluateStrength(string password);
    }
}