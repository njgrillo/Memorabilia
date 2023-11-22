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

    public DateTime CreatedDate
        => _privateSigning.CreatedDate;

    public UserModel CreatedUser
        => new(_privateSigning.CreatedUser);

    public bool DisplayDetails { get; set; }

    public int Id
        => _privateSigning.Id;

    public string Note
        => _privateSigning.Note;

    public PrivateSigningPersonModel[] People
        => _privateSigning?.People?
                           .Select(person => new PrivateSigningPersonModel(person))?
                           .ToArray() ?? [];

    public string PromoterImageFileName
        => _privateSigning.PromoterImageFileName;

    public bool SelfAddressedStampedEnvelopeAccepted
        => _privateSigning.SelfAddressedStampedEnvelopeAccepted;

    public DateTime SigningDate
        => _privateSigning.SigningDate;

    public DateTime SubmissionDeadlineDate
        => _privateSigning.SubmissionDeadlineDate;

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandLess;
}
