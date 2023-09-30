namespace Memorabilia.Application.Features.Services.Interfaces;

public interface IDataProtectorService
{
    string Encrypt(string key);

    string EncryptId(int id);

    string Decrypt(string key);

    int DecryptId(string value);
}
