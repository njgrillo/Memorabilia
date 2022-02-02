namespace Memorabilia.Domain.Entities
{
    public class Team : Framework.Domain.Entity.DomainEntity
    {
        public Team() { }

        public Team(int franchiseId, string name, string location, string nickname, string abbreviation, int? beginYear, int? endYear, string imagePath)
        {
            FranchiseId = franchiseId;
            Name = name;
            Location = location;
            Nickname = nickname;
            Abbreviation = abbreviation;
            BeginYear = beginYear;
            EndYear = endYear;
            ImagePath = imagePath;
        }

        public string Abbreviation { get; private set; }

        public int? BeginYear { get; private set; }

        public int? EndYear { get; private set; }

        public Franchise Franchise { get; private set; }

        public int FranchiseId { get; private set; }

        public string ImagePath { get; private set; }

        public string Location { get; private set; }

        public string Name { get; private set; }

        public string Nickname { get; private set; }

        public void Set(string name, string location, string nickname, string abbreviation, int? beginYear, int? endYear, string imagePath)
        {
            Name = name;
            Location = location;
            Nickname = nickname;
            Abbreviation = abbreviation;
            BeginYear = beginYear;
            EndYear = endYear;
            ImagePath = imagePath;
        }
    }
}
