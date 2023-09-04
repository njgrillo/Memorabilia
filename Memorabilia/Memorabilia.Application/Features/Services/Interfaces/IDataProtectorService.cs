namespace Memorabilia.Application.Features.Services.Interfaces;

public interface IDataProtectorService
{
    string EncryptId(int id);

    int DecryptId(string value);
}
