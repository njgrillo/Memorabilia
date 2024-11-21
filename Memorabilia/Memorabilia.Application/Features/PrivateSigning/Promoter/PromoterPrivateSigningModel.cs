namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

public class PromoterPrivateSigningModel
{
    private readonly Entity.PrivateSigning _privateSigning;

    public PromoterPrivateSigningModel() { }

    public PromoterPrivateSigningModel(Entity.PrivateSigning privateSigning)
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

    public bool IsMultiPersonSigning
        => People.Length > 1;

    public string Note
        => _privateSigning.Note;

    public PrivateSigningPersonModel[] People
        => _privateSigning?.People?
                           .Select(person => new PrivateSigningPersonModel(person))?
                           .OrderBy(person => person.Person.DisplayName)
                           .ToArray() ?? [];

    public string PromoterImageFileName
        => _privateSigning.PromoterImageFileName.IsNullOrEmpty()
            ? Constant.ImageFileName.ImageNotAvailable
            : _privateSigning.PromoterImageFileName;

    public bool SelfAddressedStampedEnvelopeAccepted
        => _privateSigning.SelfAddressedStampedEnvelopeAccepted;

    public string Signer
        => People.HasAny() ? People.First().Person.DisplayName : "No signers found.";

    public string Signers
    {
        get
        {
            return People.HasAny()
                ? (IsMultiPersonSigning
                    ? "Multiple Signers" 
                    : People.First().Person.DisplayName)
                : "No signers found.";
        }
    }

    public string Status
    {
        get
        {
            if (People.Length == 0)
                return Constant.PrivateSigningStatus.Pending.Name;            

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.Completed.Id))
                return Constant.PrivateSigningStatus.Completed.Name;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.InProgress.Id))
                return Constant.PrivateSigningStatus.InProgress.Name;

            if (People.All(x => x.StatusId == Constant.PrivateSigningStatus.OnHold.Id))
                return Constant.PrivateSigningStatus.OnHold.Name;

            if (People.Any(x => x.StatusId == Constant.PrivateSigningStatus.Completed.Id) ||
                People.Any(x => x.StatusId == Constant.PrivateSigningStatus.InProgress.Id) ||
                People.Any(x => x.StatusId == Constant.PrivateSigningStatus.OnHold.Id))
                return Constant.PrivateSigningStatus.InProgress.Name;

            return Constant.PrivateSigningStatus.Pending.Name;
        }
    }

    public DateTime SubmissionDeadlineDate
        => _privateSigning.SubmissionDeadlineDate;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandLess;
}
