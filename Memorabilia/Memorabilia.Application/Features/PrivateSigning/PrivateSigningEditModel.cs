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

        MultiDaySigning = privateSigning.EndSigningDate.HasValue;
        Published = privateSigning.Published;
        PublishedDate = privateSigning.PublishedDate;
    }

    public PrivateSigningEditModel(int id)
    {
        Id = id;
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

    public Constant.PrivateSigningStatus PrivateSigningStatus
    {
        get
        {
            if (People.Count == 0)
                return Constant.PrivateSigningStatus.Pending;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.Completed.Id))
                return Constant.PrivateSigningStatus.Completed;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.InProgress.Id))
                return Constant.PrivateSigningStatus.InProgress;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.OnHold.Id))
                return Constant.PrivateSigningStatus.OnHold;

            if (People.Any(x => x.StatusId == Constant.PrivateSigningStatus.Completed.Id) ||
                People.Any(x => x.StatusId == Constant.PrivateSigningStatus.InProgress.Id) ||
                People.Any(x => x.StatusId == Constant.PrivateSigningStatus.OnHold.Id))
                return Constant.PrivateSigningStatus.InProgress;

            return Constant.PrivateSigningStatus.Pending;
        }
    }

    public string PromoterImageFileName { get; set; }

    public List<PromoterProvidedItemEditModel> ProvidedItems { get; set; }
        = [];

    public bool Published { get; set; }

    public DateTime? PublishedDate { get; set; }

    public MudBlazor.Severity PublishedSeverity
        => Published ? MudBlazor.Severity.Success : MudBlazor.Severity.Info;

    public string PublishedStatus
        => Published ? $"Published: {PublishedDate.Value:MM-dd-yyyy hh:mm:ss tt}" : "Not Yet Published";    

    public bool SelfAddressedStampedEnvelopeAccepted { get; set; }

    public string Status
    {
        get
        {
            var status = "Status: ";

            if (People.Count == 0)
                return status + PrivateSigningStatus?.Name;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.Completed.Id))
                return status + PrivateSigningStatus?.Name;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.InProgress.Id))
                return status + PrivateSigningStatus?.Name;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.OnHold.Id))
                return status + PrivateSigningStatus?.Name;

            if (People.Any(x => x.StatusId == Constant.PrivateSigningStatus.Completed.Id) ||
                People.Any(x => x.StatusId == Constant.PrivateSigningStatus.InProgress.Id) ||
                People.Any(x => x.StatusId == Constant.PrivateSigningStatus.OnHold.Id))
                return status + PrivateSigningStatus?.Name;

            return status + PrivateSigningStatus?.Name;
        }
    }

    public MudBlazor.Severity StatusSeverity
    {
        get
        {
            if (PrivateSigningStatus is null)
                return MudBlazor.Severity.Info;

            if (PrivateSigningStatus.Id == Constant.PrivateSigningStatus.Completed.Id)
                return MudBlazor.Severity.Success;

            if (PrivateSigningStatus.Id == Constant.PrivateSigningStatus.InProgress.Id)
                return MudBlazor.Severity.Normal;

            if (PrivateSigningStatus.Id == Constant.PrivateSigningStatus.OnHold.Id)
                return MudBlazor.Severity.Warning;

            return MudBlazor.Severity.Info;
        }
    } 

    public DateTime? SubmissionDeadlineDate { get; set; }
}
