namespace Memorabilia.Domain.Entities
{
    public class Franchise : Framework.Library.Domain.Entity.DomainEntity
    {
        public Franchise() { }

        public Franchise(int sportLeagueLevelId, string name, string location, int foundYear)
        {
            SportLeagueLevelId = sportLeagueLevelId;
            Name = name;
            Location = location;
            FoundYear = foundYear;
            CreateDate = DateTime.UtcNow;
        }

        public DateTime CreateDate { get; private set; }

        public int FoundYear { get; private set; }

        public string FullName => $"{Location} {Name}";

        public string ImagePath { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public string Location { get; private set; }

        public string Name { get; private set; }

        public virtual SportLeagueLevel SportLeagueLevel { get; private set; }

        public int SportLeagueLevelId { get; private set; }

        public string SportLeagueLevelName => Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;

        public void Set(string name, string location, int foundYear)
        {
            Name = name;
            Location = location;
            FoundYear = foundYear;
        }
    }
}
