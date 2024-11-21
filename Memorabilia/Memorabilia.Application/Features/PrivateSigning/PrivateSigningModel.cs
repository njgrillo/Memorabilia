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

    public DateOnly? BeginSigningDate
        => _privateSigning.BeginSigningDate;

    public DateTime CreatedDate 
		=> _privateSigning.CreatedDate;

	public UserModel CreatedUser
		=> new(_privateSigning.CreatedUser);

	public bool DisplayDetails { get; set; }

    public DateOnly? EndSigningDate
        => _privateSigning.EndSigningDate;

    public int Id
		=> _privateSigning.Id;

	public string Note 
		=> _privateSigning.Note;

	public PrivateSigningPaymentOptionModel[] PaymentOptions
        => _privateSigning?.PaymentOptions?
                           .Select(option => new PrivateSigningPaymentOptionModel(option))?
                           .ToArray() ?? [];

    public PrivateSigningPersonModel[] People
		=> _privateSigning?.People?
						   .Select(person => new PrivateSigningPersonModel(person))?
						   .ToArray() ?? [];

	public string PromoterImageFileName
        => _privateSigning.PromoterImageFileName.IsNullOrEmpty()
            ? Constant.ImageFileName.ImageNotAvailable
            : _privateSigning.PromoterImageFileName;

    public PromoterProvidedItemModel[] PromoterProvidedItems
		=> _privateSigning?.PromoterProvidedItems?
						   .Select(privateSigningPromoterProvidedItem => new PromoterProvidedItemModel(privateSigningPromoterProvidedItem.PromoterProvidedItem))?
						   .ToArray() ?? [];

	public bool SelfAddressedStampedEnvelopeAccepted
		=> _privateSigning.SelfAddressedStampedEnvelopeAccepted;	

	public DateTime SubmissionDeadlineDate
		=> _privateSigning.SubmissionDeadlineDate;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandLess;
}
