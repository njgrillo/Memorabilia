namespace Memorabilia.Application.Features.Services.Security;

public class DataProtectorDebugService : IDataProtectorService
{
    public string Encrypt(string key)
        => key;

    public string EncryptId(int id)
        => id.ToString();

    public string Decrypt(string key)
        => key;

    public int DecryptId(string value)
    {
        _ = int.TryParse(value, out int result);

        return result;
    }  
}
