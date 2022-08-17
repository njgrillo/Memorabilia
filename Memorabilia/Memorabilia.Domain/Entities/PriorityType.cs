namespace Memorabilia.Domain.Entities
{
    public class PriorityType : DomainEntity
    {
        public PriorityType() { }

        public PriorityType(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
