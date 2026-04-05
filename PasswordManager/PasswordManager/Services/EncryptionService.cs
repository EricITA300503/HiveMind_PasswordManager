// ============================================================
// File:    EncryptionService.cs
// Author:  Maurice Henriques
// Purpose: Encrypts and decrypts vault passwords using the
//          ASP.NET Core Data Protection API.
// ============================================================
using Microsoft.AspNetCore.DataProtection;

public class EncryptionService : IEncryptionService
{
    private readonly IDataProtector _protector;

    public EncryptionService(IDataProtectionProvider provider)
        => _protector = provider.CreateProtector("PasswordManager.VaultEntry");

    public string Encrypt(string plainText) => _protector.Protect(plainText);
    public string Decrypt(string cipherText) => _protector.Unprotect(cipherText);
}
