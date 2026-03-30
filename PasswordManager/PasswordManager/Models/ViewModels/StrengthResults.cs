using System.Collections.Generic;

namespace PasswordManager.Models.ViewModels
{

    public class StrengthResult
    {
        public int Score { get; set; }

        public string Label { get; set; } = string.Empty;

        public string? Warning { get; set; }

        public List<string> Suggestions { get; set; } = new List<string>();
    }
}