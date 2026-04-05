// ============================================================
// File:    VaultEntry.cs
// Author:  Maurice Henriques
// Purpose: Entity class for a saved credential. Password
//          field stores AES-encrypted ciphertext only.
// ============================================================
using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    public class VaultEntry
    {
        [Key]
        public int _entryId { get; set; }
        public string _userId { get; set; } = string.Empty;
        public string _siteName { get; set; } = string.Empty;
        public string _siteUrl { get; set; } = string.Empty;
        public string _username { get; set; } = string.Empty;

        
        public string _encryptedPassword { get; set; } = string.Empty;

        public string? _notes { get; set; }
        public int? _categoryId { get; set; }

        public DateTime _createdAt { get; set; } = DateTime.UtcNow;
        public DateTime _updatedAt { get; set; } = DateTime.UtcNow;

        
        public ApplicationUser? User { get; set; }
        public Category? Category { get; set; }
    }
}