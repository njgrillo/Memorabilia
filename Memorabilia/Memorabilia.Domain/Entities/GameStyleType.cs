namespace Memorabilia.Domain.Entities
{
    public class GameStyleType : DomainEntity
    {
        public GameStyleType() { }

        public GameStyleType(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
