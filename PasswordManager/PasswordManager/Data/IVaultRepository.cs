using PasswordManager.Models;

namespace PasswordManager.Data
{

    //Repository for vault entry data

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
