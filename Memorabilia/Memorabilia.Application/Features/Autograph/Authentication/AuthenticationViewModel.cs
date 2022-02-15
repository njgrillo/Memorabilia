namespace Memorabilia.Application.Features.Autograph.Authentication
{
    public class AuthenticationViewModel
    {
        private readonly Domain.Entities.AutographAuthentication _authentication;

        public AuthenticationViewModel() { }

        public AuthenticationViewModel(Domain.Entities.AutographAuthentication authentication)
        {
            _authentication = authentication;
        }

        public int AuthenticationCompanyId => _authentication.AuthenticationCompanyId;

        public int AutographId => _authentication.AutographId;

        public bool? HasHologram => _authentication.HasHologram;

        public bool? HasLetter => _authentication.HasLetter;

        public int Id => _authentication.Id;

        public string Verification => _authentication.Verification;
    }
}
