using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Autograph.Authentication;

public class AuthenticationViewModel
{
    private readonly AutographAuthentication _authentication;

    public AuthenticationViewModel() { }

    public AuthenticationViewModel(AutographAuthentication authentication)
    {
        _authentication = authentication;
    }

    public int AuthenticationCompanyId => _authentication.AuthenticationCompanyId;

    public int AutographId => _authentication.AutographId;

    public bool? HasCertificationCard => _authentication.HasCertificationCard;

    public bool? HasHologram => _authentication.HasHologram;

    public bool? HasLetter => _authentication.HasLetter;

    public int Id => _authentication.Id;

    public string Verification => _authentication.Verification;

    public bool Witnessed => _authentication.Witnessed;
}
