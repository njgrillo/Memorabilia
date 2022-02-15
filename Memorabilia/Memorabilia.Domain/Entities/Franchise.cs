using System;

namespace Memorabilia.Domain.Entities
{
    public class Franchise : Framework.Domain.Entity.DomainEntity
    {
        public Franchise() { }

        public Franchise(int sportId, string name, string location, int foundYear)
        {
            SportId = sportId;
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

        public int SportId { get; private set; }

        public string SportName => Constants.Sport.Find(SportId)?.Name;

        public void Set(string name, string location, int foundYear)
        {
            Name = name;
            Location = location;
            FoundYear = foundYear;
        }
    }
}
