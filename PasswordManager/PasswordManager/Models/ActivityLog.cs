using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    public class ActivityLog
    {
        [Key]
        public int _logId { get; set; }
        public string _userId { get; set; } = string.Empty;
        public string _action { get; set; } = string.Empty;
        public string _ipAddress { get; set; } = string.Empty;

        public DateTime _timestamp { get; set; } = DateTime.UtcNow;

        public ApplicationUser? User { get; set; }
    }
}