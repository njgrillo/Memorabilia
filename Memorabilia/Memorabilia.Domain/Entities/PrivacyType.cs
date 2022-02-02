namespace Memorabilia.Domain.Entities
{
    public class PrivacyType : DomainEntity
    {
        public PrivacyType() { }

        public PrivacyType(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
