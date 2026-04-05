// ============================================================
// File:    PasswordOptions.cs
// Author:  Benjamin Mathies
// Purpose: ViewModel for password generator options. Sent
//          as JSON body to the generate API endpoint.
// ============================================================
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