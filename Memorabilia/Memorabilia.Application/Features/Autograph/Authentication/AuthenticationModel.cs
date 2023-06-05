namespace Memorabilia.Application.Features.Autograph.Authentication;

public class AuthenticationModel
{
    private readonly Entity.AutographAuthentication _authentication;

    public AuthenticationModel() { }

    public AuthenticationModel(Entity.AutographAuthentication authentication)
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
