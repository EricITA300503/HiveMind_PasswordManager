using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.Models
{
    public class Category
    {
        [Key]
        public int _categoryId { get; set; }
        public string _userId { get; set; } = string.Empty;
        public string _name { get; set; } = string.Empty;

   
        public ApplicationUser? User { get; set; }
        public ICollection<VaultEntry> VaultEntries { get; set; } = new List<VaultEntry>();
    }
}