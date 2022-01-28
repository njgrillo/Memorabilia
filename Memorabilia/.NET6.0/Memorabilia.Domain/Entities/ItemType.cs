namespace Memorabilia.Domain.Entities
{
    public class ItemType : DomainEntity
    {
        public ItemType() { }

        public ItemType(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
