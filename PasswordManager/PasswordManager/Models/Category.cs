namespace PasswordManager.Models
{
    /// <summary>
    /// A user-defined category for organising vault entries.
    /// Author: Benjamin Mathies
    /// </summary>
    public class Category
    {
        public int _categoryId { get; set; }
        public string _userId { get; set; } = string.Empty;
        public string _name { get; set; } = string.Empty;

        public ApplicationUser? User { get; set; }
        public ICollection<VaultEntry> VaultEntries { get; set; } = new List<VaultEntry>();
    }
}
