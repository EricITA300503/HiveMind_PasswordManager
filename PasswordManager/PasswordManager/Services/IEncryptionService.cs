// ============================================================
// File:    IEncryptionService.cs
// Author:  Maurice Henriques
// Purpose: Contract interface for the encryption service.
// ============================================================
public interface IEncryptionService
{
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}
