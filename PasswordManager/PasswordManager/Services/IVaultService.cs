// Services/IVaultService.cs
public interface IVaultService
{
    IEnumerable<VaultEntry> SearchEntries(string userId, string? query, int? catId);
    VaultEntry? GetById(int id);
    Task CreateEntryAsync(VaultEntry entry);
    Task UpdateEntryAsync(VaultEntry entry);
    void DeleteEntry(int id);
}
