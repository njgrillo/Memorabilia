namespace Memorabilia.Domain.Entities
{
    public class AutographAuthentication : Framework.Domain.Entity.DomainEntity
    {
        public AutographAuthentication() { }

        public AutographAuthentication(int authenticationCompanyId, 
                                       int autographId, 
                                       bool? hasCertificationCard,
                                       bool? hasHologram, 
                                       bool? hasLetter, 
                                       string verification,
                                       bool witnessed)
        {
            AuthenticationCompanyId = authenticationCompanyId;
            AutographId = autographId;
            HasCertificationCard = hasCertificationCard;
            HasHologram = hasHologram;
            HasLetter = hasLetter;
            Verification = verification;
            Witnessed = witnessed;
        }

        public int AuthenticationCompanyId { get; private set; }

        public int AutographId { get; private set; }

        public bool? HasCertificationCard { get; private set; }

        public bool? HasHologram { get; private set; }

        public bool? HasLetter { get; private set; }

        public string Verification { get; private set; }

        public bool Witnessed { get; private set; }

        public void Set(int authenticationCompanyId,
                        bool? hasCertificationCard,
                        bool? hasHologram, 
                        bool? hasLetter, 
                        string verification,
                        bool witnessed)
        {
            AuthenticationCompanyId = authenticationCompanyId;
            HasCertificationCard = hasCertificationCard;
            HasHologram = hasHologram;
            HasLetter = hasLetter;
            Verification = verification;
            Witnessed = witnessed;
        }
    }
}
