namespace Memorabilia.Domain.Entities
{
    public class WritingInstrument : DomainEntity
    {
        public WritingInstrument() { }

        public WritingInstrument(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
