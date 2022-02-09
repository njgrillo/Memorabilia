namespace Memorabilia.Domain.Entities
{
    public class AutographAuthentication : Framework.Domain.Entity.DomainEntity
    {
        public AutographAuthentication() { }

        public AutographAuthentication(int authenticationCompanyId, int autographId, bool? hasHologram, bool? hasLetter, string verification)
        {
            AuthenticationCompanyId = authenticationCompanyId;
            AutographId = autographId;
            HasHologram = hasHologram;
            HasLetter = hasLetter;
            Verification = verification;
        }

        public int AuthenticationCompanyId { get; private set; }

        public int AutographId { get; private set; }

        public bool? HasHologram { get; private set; }

        public bool? HasLetter { get; private set; }

        public string Verification { get; private set; }

        public void Set(int authenticationCompanyId, bool? hasHologram, bool? hasLetter, string verification)
        {
            AuthenticationCompanyId = authenticationCompanyId;
            HasHologram = hasHologram;
            HasLetter = hasLetter;
            Verification = verification;
        }
    }
}
