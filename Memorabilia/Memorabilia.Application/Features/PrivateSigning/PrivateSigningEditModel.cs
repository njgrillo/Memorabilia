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
        BeginSigningDate = privateSigning.BeginSigningDate?.ToDateTime(TimeOnly.MinValue);
        CreatedByUserId = privateSigning.CreatedUserId;
        CreatedDate = privateSigning.CreatedDate;
        EndSigningDate = privateSigning.EndSigningDate?.ToDateTime(TimeOnly.MinValue);
        Id = privateSigning.Id;
        Note = privateSigning.Note; 
        PromoterImageFileName = privateSigning.PromoterImageFileName;
        SelfAddressedStampedEnvelopeAccepted = privateSigning.SelfAddressedStampedEnvelopeAccepted;
        SubmissionDeadlineDate = privateSigning.SubmissionDeadlineDate;

        AuthenticationCompanies = privateSigning.AuthenticationCompanies
                                                .Select(company => new PrivateSigningAuthenticationCompanyEditModel(company))
                                                .ToList();

        PaymentOptions = privateSigning.PaymentOptions
                                       .Select(option => new PrivateSigningPaymentOptionEditModel(option))
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

    public DateTime? BeginSigningDate { get; set; }

    public bool CanMarkAsComplete
        => People.Count > 0 && People.Any(x => x.StatusId != Constant.PrivateSigningStatus.Completed.Id);

    public UserModel CreatedByUser { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? EndSigningDate { get; set; }

    public bool MultiDaySigning { get; set; }

    public string Note { get; set; }

    public List<PrivateSigningPaymentOptionEditModel> PaymentOptions { get; set; }
        = [];

    public List<PrivateSigningPersonEditModel> People { get; set; }
        = [];

    public string PromoterImageFileName { get; set; }

    public List<PromoterProvidedItemEditModel> ProvidedItems { get; set; }
        = [];

    public bool SelfAddressedStampedEnvelopeAccepted { get; set; }   

    public DateTime? SubmissionDeadlineDate { get; set; }
}
