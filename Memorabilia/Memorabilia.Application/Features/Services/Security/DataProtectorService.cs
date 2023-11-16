namespace Memorabilia.Application.Features.Services.Security;

public class DataProtectorService : IDataProtectorService	
{
	private readonly IDataProtectionProvider _dataProtectionProvider;
	private readonly IDataProtector _dataProtector;

	public DataProtectorService(IDataProtectionProvider dataProtectionProvider)
	{
        _dataProtectionProvider = dataProtectionProvider;
        _dataProtector = _dataProtectionProvider.CreateProtector("GraphinAllDay");
    }

	public string Encrypt(string key)
        => _dataProtector.Protect(key);


    public string EncryptId(int id)
	    => _dataProtector.Protect(id.ToString());

    public string Decrypt(string key)
        => _dataProtector.Unprotect(key);

    public int DecryptId(string value)
	{
        _ = int.TryParse(_dataProtector.Unprotect(value), out int result);

        return result;
    }
}
