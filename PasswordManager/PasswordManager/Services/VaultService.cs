using PasswordManager.Data;
using PasswordManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasswordManager.Services
{
    public class VaultService : IVaultService
    {
        private IVaultRepository _repo;

        public VaultService(IVaultRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<VaultEntry> SearchEntries(string userId, string? search, int? catId)
        {
            var query = _repo.GetAll(userId);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(v => v._siteName.Contains(search) || v._username.Contains(search));
            }

            if (catId.HasValue)
            {
                query = query.Where(v => v._categoryId == catId.Value);
            }

            return query.ToList();
        }

        public VaultEntry? GetEntryById(int id)
        {
            return _repo.GetById(id);
        }

        public async Task CreateEntryAsync(VaultEntry entry)
        {
            _repo.Add(entry);
            _repo.Save(); 

            await Task.CompletedTask;
        }

        public async Task UpdateEntryAsync(VaultEntry entry)
        {
            _repo.Update(entry);
            _repo.Save();

            await Task.CompletedTask;
        }

        public async Task DeleteEntryAsync(int id)
        {
            _repo.Delete(id);
            _repo.Save();

            await Task.CompletedTask;
        }
    }
}