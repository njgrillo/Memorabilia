namespace Memorabilia.Domain.Entities
{
    public class InscriptionType : DomainEntity
    {
        public InscriptionType() { }

        public InscriptionType(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
