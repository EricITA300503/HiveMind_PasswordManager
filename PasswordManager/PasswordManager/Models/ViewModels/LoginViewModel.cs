// ============================================================
// File:    LoginViewModel.cs
// Author:  Miguel Lumaban
// Purpose: ViewModel for the login form (email + password).
// ============================================================
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
    }
}
