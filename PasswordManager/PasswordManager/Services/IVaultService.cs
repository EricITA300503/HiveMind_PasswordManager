using PasswordManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public interface IVaultService
    {
        IEnumerable<VaultEntry> SearchEntries(string userId, string? search, int? catId);
        VaultEntry? GetEntryById(int id);
        Task CreateEntryAsync(VaultEntry entry);
        Task UpdateEntryAsync(VaultEntry entry);
        Task DeleteEntryAsync(int id);
    }
}