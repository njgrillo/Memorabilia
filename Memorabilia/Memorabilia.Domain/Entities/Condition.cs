namespace Memorabilia.Domain.Entities
{
    public class Condition : DomainEntity
    {
        public Condition() { }

        public Condition(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
