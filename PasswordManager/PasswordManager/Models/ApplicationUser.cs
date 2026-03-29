using Microsoft.AspNetCore.Identity;

namespace PasswordManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string _fullName { get; set; } = string.Empty;
        public bool _isActive { get; set; } = true;
        public DateTime _createdAt { get; set; } = DateTime.UtcNow;
    }
}
