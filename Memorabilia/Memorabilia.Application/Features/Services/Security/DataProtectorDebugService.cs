namespace Memorabilia.Application.Features.Services.Security;

public class DataProtectorDebugService : IDataProtectorService
{
    public string EncryptId(int id)
        => id.ToString();

    public int DecryptId(string value)
    {
        _ = int.TryParse(value, out int result);

        return result;
    }
}
