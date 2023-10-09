namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningModel
{
	private readonly Entity.PrivateSigning _privateSigning;

	public PrivateSigningModel() { }

	public PrivateSigningModel(Entity.PrivateSigning privateSigning)
	{
        _privateSigning = privateSigning;
    }

	public PrivateSigningAuthenticationCompanyModel[] AuthenticationCompanies
		=> _privateSigning.AuthenticationCompanies
						  .Select(company => new PrivateSigningAuthenticationCompanyModel(company))
						  .ToArray();

	public DateTime CreatedDate 
		=> _privateSigning.CreatedDate;

	public UserModel CreatedUser
		=> new(_privateSigning.CreatedUser);

	public bool DisplayDetails { get; set; }
		= true;

    public int Id
		=> _privateSigning.Id;

	public string Note 
		=> _privateSigning.Note;

	public PrivateSigningPersonModel[] People
		=> _privateSigning?.People?
						   .Select(person => new PrivateSigningPersonModel(person))?
						   .ToArray() ?? Array.Empty<PrivateSigningPersonModel>();

	public PromoterProvidedItemModel[] PromoterProvidedItems
		=> _privateSigning?.PromoterProvidedItems?
						   .Select(privateSigningPromoterProvidedItem => new PromoterProvidedItemModel(privateSigningPromoterProvidedItem.PromoterProvidedItem))?
						   .ToArray() ?? Array.Empty<PromoterProvidedItemModel>();

	public bool SelfAddressedStampedEnvelopeAccepted
		=> _privateSigning.SelfAddressedStampedEnvelopeAccepted;

	public DateTime SigningDate
		=> _privateSigning.SigningDate;

	public DateTime SubmissionDeadlineDate
		=> _privateSigning.SubmissionDeadlineDate;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandLess;
}
