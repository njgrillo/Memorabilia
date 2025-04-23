namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningAuthenticationCompanyEditModel : EditModel
{
	public PrivateSigningAuthenticationCompanyEditModel() { }

	public PrivateSigningAuthenticationCompanyEditModel(Entity.PrivateSigningAuthenticationCompany privateSigningAuthenticationCompany)
	{
		AuthenticationCompanyId = privateSigningAuthenticationCompany.AuthenticationCompanyId;
		Cost = privateSigningAuthenticationCompany.Cost;
		Id = privateSigningAuthenticationCompany.Id;
		PrivateSigningId = privateSigningAuthenticationCompany.Id;
	}	 
	 
	public Constant.AuthenticationCompany AuthenticationCompany
		=> Constant.AuthenticationCompany.Find(AuthenticationCompanyId);

	public int AuthenticationCompanyId { get; set; }

	public string AuthenticationCompanyName
		=> AuthenticationCompany != null
			? $"{AuthenticationCompany.Name} {(!AuthenticationCompany.Abbreviation.IsNullOrEmpty() ? $"({AuthenticationCompany.Abbreviation})" : string.Empty)}"
			: string.Empty;

    public decimal? Cost { get; set; }

	public int PrivateSigningId { get; set; }
}
