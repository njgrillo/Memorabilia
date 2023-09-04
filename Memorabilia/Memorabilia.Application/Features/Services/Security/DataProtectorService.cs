namespace Memorabilia.Application.Features.Services.Security;

public class DataProtectorService : IDataProtectorService	
{
	private readonly IDataProtectionProvider _dataProtectionProvider;
	private IDataProtector _dataProtector;

	public DataProtectorService(IDataProtectionProvider dataProtectionProvider)
	{
        _dataProtectionProvider = dataProtectionProvider;
	}

	public string EncryptId(int id)
	{
		_dataProtector = _dataProtectionProvider.CreateProtector("GraphinAllDay");

		return _dataProtector.Protect(id.ToString());
    }

	public int DecryptId(string value)
	{
        _ = int.TryParse(_dataProtector.Unprotect(value), out int result);

        return result;
    }
}
