// ============================================================
// File:    ErrorViewModel.cs
// Author:  Eric Bertero
// Purpose: ViewModel for the shared error page.
// ============================================================
namespace PasswordManager.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
