namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningAuthenticationCompanyModel
{
	private readonly Entity.PrivateSigningAuthenticationCompany _privateSigningAuthenticationCompany;

	public PrivateSigningAuthenticationCompanyModel() { }

	public PrivateSigningAuthenticationCompanyModel(Entity.PrivateSigningAuthenticationCompany privateSigningAuthenticationCompany)
	{
        _privateSigningAuthenticationCompany = privateSigningAuthenticationCompany;
    }

	public Constant.AuthenticationCompany AuthenticationCompany
		=> Constant.AuthenticationCompany.Find(AuthenticationCompanyId);

	public int AuthenticationCompanyId
		=> _privateSigningAuthenticationCompany.AuthenticationCompanyId;

	public decimal Cost
		=> _privateSigningAuthenticationCompany.Cost;

	public int Id
		=> _privateSigningAuthenticationCompany.Id;

	public int PrivateSigningId
		=> _privateSigningAuthenticationCompany.PrivateSigningId;
}
