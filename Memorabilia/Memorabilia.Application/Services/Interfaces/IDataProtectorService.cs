namespace Memorabilia.Application.Services.Interfaces;

public interface IDataProtectorService
{
    string Encrypt(string key);

    string EncryptId(int id);

    string Decrypt(string key);

    int DecryptId(string value);
}
