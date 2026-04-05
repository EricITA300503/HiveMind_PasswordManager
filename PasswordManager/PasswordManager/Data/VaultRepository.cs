// ============================================================
// File:    VaultRepository.cs
// Author:  Maurice Henriques
// Purpose: EF Core implementation of IVaultRepository.
//          Handles all database operations for vault entries.
// ============================================================
using PasswordManager.Models;

namespace PasswordManager.Data
{
    public class VaultRepository : IVaultRepository
    {
        private readonly AppDbContext _context;



        public VaultRepository(AppDbContext context) => _context = context;

        public IQueryable<VaultEntry> GetAll(string userId) =>
            _context.VaultEntries.Where(v => v._userId == userId);

        public VaultEntry? GetById(int id) =>
            _context.VaultEntries.FirstOrDefault(v => v._entryId == id);

        public void Add(VaultEntry entry) => _context.VaultEntries.Add(entry);


        public void Update(VaultEntry entry) => _context.VaultEntries.Update(entry);


        public void Delete(int id)
        {
            var entry = GetById(id);



            if (entry != null) _context.VaultEntries.Remove(entry);
        }

        //Save
        public void Save() => _context.SaveChanges();
    }
}
