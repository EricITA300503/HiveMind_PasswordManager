namespace PasswordManager.Models.ViewModels
{
    /// <summary>Result returned by the password strength API endpoint.</summary>
    public class StrengthResult
    {
        public int Score { get; set; }        // 0 = Weak, 4 = Very Strong
        public string Label { get; set; } = string.Empty;
        public List<string> Tips { get; set; } = new();
    }
}
