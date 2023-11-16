namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningEditModel : EditModel
{
	public PrivateSigningEditModel() { }

    public PrivateSigningEditModel(Entity.User createdUser)
    {
        CreatedByUser = new UserModel(createdUser);
        CreatedByUserId = createdUser.Id;
    }

    public PrivateSigningEditModel(Entity.PrivateSigning privateSigning)
    {
        CreatedByUserId = privateSigning.CreatedUserId;
        CreatedDate = privateSigning.CreatedDate;
        Id = privateSigning.Id;
        Note = privateSigning.Note; 
        PromoterImageFileName = privateSigning.PromoterImageFileName;
        SelfAddressedStampedEnvelopeAccepted = privateSigning.SelfAddressedStampedEnvelopeAccepted;
        SigningDate = privateSigning.SigningDate;
        SubmissionDeadlineDate = privateSigning.SubmissionDeadlineDate;

        AuthenticationCompanies = privateSigning.AuthenticationCompanies
                                                .Select(company => new PrivateSigningAuthenticationCompanyEditModel(company))
                                                .ToList();

        People = privateSigning.People
                               .Select(person => new PrivateSigningPersonEditModel(person))
                               .ToList();

        ProvidedItems = privateSigning.PromoterProvidedItems
                                      .Select(item => new PromoterProvidedItemEditModel(item.PromoterProvidedItem))
                                      .ToList();
    }

    public List<PrivateSigningAuthenticationCompanyEditModel> AuthenticationCompanies { get; set; }
        = [];

    public UserModel CreatedByUser { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }    

	public string Note { get; set; }

    public List<PrivateSigningPersonEditModel> People { get; set; }
        = [];

    public string PromoterImageFileName { get; set; }

    public List<PromoterProvidedItemEditModel> ProvidedItems { get; set; }
        = [];

    public bool SelfAddressedStampedEnvelopeAccepted { get; set; }

    public DateTime? SigningDate { get; set; }

    public DateTime? SubmissionDeadlineDate { get; set; }
}
