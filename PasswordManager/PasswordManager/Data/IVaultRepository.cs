// ============================================================
// File:    IVaultRepository.cs
// Author:  Maurice Henriques
// Purpose: Repository interface for vault entry data access.
// ============================================================
using PasswordManager.Models;

namespace PasswordManager.Data
{
    public interface IVaultRepository
    {
        IQueryable<VaultEntry> GetAll(string userId);


        VaultEntry? GetById(int id);


        void Add(VaultEntry entry);


        void Update(VaultEntry entry);

        void Delete(int id);


        void Save();
    }
}
