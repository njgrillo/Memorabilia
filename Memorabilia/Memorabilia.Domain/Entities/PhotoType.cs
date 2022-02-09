namespace Memorabilia.Domain.Entities
{
    public class PhotoType : DomainEntity
    {
        public PhotoType() { }

        public PhotoType(string name, string abbreviation) : base(name, abbreviation) { }
    }
}
