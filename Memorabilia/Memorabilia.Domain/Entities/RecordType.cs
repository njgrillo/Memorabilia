namespace Memorabilia.Domain.Entities
{
    public class RecordType : DomainEntity
    {
        public RecordType() { }

        public RecordType(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
