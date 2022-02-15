namespace Memorabilia.Domain.Entities
{
    public class Conference : Framework.Domain.Entity.DomainEntity
    {
        public Conference() { }

        public Conference(int sportId, string name, string abbreviation)
        {
            SportId = sportId;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; set; }

        public string Name { get; set; }

        public int SportId { get; set; }

        public void Set(int sportId, string name, string abbreviation)
        {
            SportId = sportId;
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
