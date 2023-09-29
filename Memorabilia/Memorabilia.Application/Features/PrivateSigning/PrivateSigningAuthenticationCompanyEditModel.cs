namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningAuthenticationCompanyEditModel : EditModel
{
	public PrivateSigningAuthenticationCompanyEditModel() { }

	public PrivateSigningAuthenticationCompanyEditModel(Entity.PrivateSigningAuthenticationCompany privateSigningAuthenticationCompany)
	{
		AuthenticationCompanyId = privateSigningAuthenticationCompany.Id;
		Cost = privateSigningAuthenticationCompany.Cost;
		PrivateSigningId = privateSigningAuthenticationCompany.Id;
	}

	public int AuthenticationCompanyId { get; set; }

	public decimal Cost { get; set; }

	public int PrivateSigningId { get; set; }
}
