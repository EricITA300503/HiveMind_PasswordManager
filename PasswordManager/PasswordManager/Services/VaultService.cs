// Services/VaultService.cs
public class VaultService : IVaultService
{
    private readonly IVaultRepository _repo;
    private readonly IEncryptionService _encryption;

    public VaultService(IVaultRepository repo, IEncryptionService encryption)
    { _repo = repo; _encryption = encryption; }

    public IEnumerable<VaultEntry> SearchEntries(string userId, string? query, int? catId)
    {
        var entries = _repo.GetAll(userId);
        if (!string.IsNullOrEmpty(query))
            entries = entries.Where(e => e._siteName.Contains(query) || e._username.Contains(query));
        if (catId.HasValue)
            entries = entries.Where(e => e._categoryId == catId);
        return entries.ToList();
    }

    public async Task CreateEntryAsync(VaultEntry entry)
    {
        // Encrypt before saving — never store plain text passwords
        entry._encryptedPassword = _encryption.Encrypt(entry._encryptedPassword);
        _repo.Add(entry);
        _repo.Save();
    }

    public VaultEntry? GetById(int id) => _repo.GetById(id);
    public void DeleteEntry(int id) { _repo.Delete(id); _repo.Save(); }
    public async Task UpdateEntryAsync(VaultEntry entry) { _repo.Update(entry); _repo.Save(); }
}
