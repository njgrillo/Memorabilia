namespace Memorabilia.Application.Features.Autograph.Authentication
{
    public class SaveAuthenticationViewModel
    {
        public SaveAuthenticationViewModel() { }

        public SaveAuthenticationViewModel(Domain.Entities.AutographAuthentication authentication)
        {
            AuthenticationCompanyId = authentication.AuthenticationCompanyId;
            AutographId = authentication.AutographId;
            HasHologram = authentication.HasHologram;
            HasLetter = authentication.HasLetter;
            Id = authentication.Id;
            Verification = authentication.Verification;
        }

        public int AuthenticationCompanyId { get; set; }

        public int AutographId { get; set; }

        public bool? HasHologram { get; set; }

        public bool? HasLetter { get; set; }

        public int Id { get; set; }        

        public string Verification { get; set; }
    }
}
