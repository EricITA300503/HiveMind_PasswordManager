using System.Security.Cryptography;
using PasswordManager.Models.ViewModels;

public class PasswordService : IPasswordService
{
    public string GeneratePassword(PasswordOptions opts)
    {
        const string lower   = "abcdefghijklmnopqrstuvwxyz";
        const string upper   = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits  = "0123456789";
        const string symbols = "!@#$%^&*()";

        var charset = lower;
        if (opts.IncludeUppercase) charset += upper;
        if (opts.IncludeNumbers)   charset += digits;
        if (opts.IncludeSymbols)   charset += symbols;

        return new string(Enumerable.Range(0, opts.Length)
            .Select(_ => charset[RandomNumberGenerator.GetInt32(charset.Length)])
            .ToArray());
    }

    public StrengthResult CheckStrength(string pw)
    {
        int score = 0;
        if (pw.Length >= 8)  score++;
        if (pw.Length >= 12) score++;
        if (pw.Any(char.IsUpper) && pw.Any(char.IsLower)) score++;
        if (pw.Any(char.IsDigit)) score++;
        if (pw.Any(c => !char.IsLetterOrDigit(c))) score++;
        score = Math.Min(score, 4);
        var labels = new[] { "Very Weak", "Weak", "Fair", "Strong", "Very Strong" };
        return new StrengthResult { Score = score, Label = labels[score] };
    }
}
