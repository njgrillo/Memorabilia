namespace Memorabilia.Application.Features.Autograph.Authentication;

public class SaveAuthenticationViewModel : SaveViewModel
{
    public SaveAuthenticationViewModel() { }

    public SaveAuthenticationViewModel(AuthenticationViewModel authentication)
    {
        AuthenticationCompanyId = authentication.AuthenticationCompanyId;
        AutographId = authentication.AutographId;
        HasCertificationCard = authentication.HasCertificationCard ?? false;
        HasHologram = authentication.HasHologram ?? false;
        HasLetter = authentication.HasLetter ?? false;
        Id = authentication.Id;
        Verification = authentication.Verification;
        Witnessed = authentication.Witnessed;
    }

    public Domain.Constants.AuthenticationCompany[] AuthenticationCompanies 
        => Domain.Constants.AuthenticationCompany.All;

    public Domain.Constants.AuthenticationCompany AuthenticationCompany 
        => Domain.Constants.AuthenticationCompany.Find(AuthenticationCompanyId);

    public int AuthenticationCompanyId { get; set; }    

    public string AuthenticationCompanyName
        => Domain.Constants.AuthenticationCompany.Find(AuthenticationCompanyId)?.Name;

    public int AutographId { get; set; }

    public bool CanNavigateToWebsite
        => (AuthenticationCompany?.IsNavigatable() ?? false) && !Verification.IsNullOrEmpty();

    public bool HasCertificationCard { get; set; }

    public bool HasHologram { get; set; }

    public bool HasLetter { get; set; }

    public string Verification { get; set; }

    public string VerificationWebsiteLink 
        => CanNavigateToWebsite 
        ? $"{AuthenticationCompany.WebsitePath}{Verification}" 
        : string.Empty;

    public string VerificationWebsiteLinkText 
        => $"Verify through {AuthenticationCompanyName}";

    public bool Witnessed { get; set; }
}
