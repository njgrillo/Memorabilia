namespace Memorabilia.Application.Features.Autograph.Authentication
{
    public class SaveAuthenticationViewModel
    {
        public SaveAuthenticationViewModel() { }

        public SaveAuthenticationViewModel(AuthenticationViewModel authentication)
        {
            AuthenticationCompanyId = authentication.AuthenticationCompanyId;
            AutographId = authentication.AutographId;
            HasHologram = authentication.HasHologram ?? false;
            HasLetter = authentication.HasLetter ?? false;
            Id = authentication.Id;
            Verification = authentication.Verification;
        }

        public int AuthenticationCompanyId { get; set; }

        public string AuthenticationCompanyName => Domain.Constants.AuthenticationCompany.Find(AuthenticationCompanyId)?.Name;

        public int AutographId { get; set; }

        public bool HasHologram { get; set; }

        public bool HasLetter { get; set; }

        public int Id { get; set; }        

        public string Verification { get; set; }
    }
}
