// ============================================================
// File:    RegisterViewModel.cs
// Author:  Miguel Lumaban
// Purpose: ViewModel for the registration form (name, email,
//          password, confirmation).
// ============================================================
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required] public string FullName { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required, MinLength(8)] public string Password { get; set; } = string.Empty;
        [Compare("Password")] public string ConfirmPassword { get; set; } = string.Empty;
    }
}
