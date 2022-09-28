namespace Memorabilia.Domain.Entities
{
    public class Conference : Framework.Library.Domain.Entity.DomainEntity
    {
        public Conference() { }

        public Conference(int sportLeagueLevelId, string name, string abbreviation)
        {
            SportLeagueLevelId = sportLeagueLevelId;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; set; }

        public string Name { get; set; }

        public int SportLeagueLevelId { get; set; }

        public string SportLeagueLevelName => Constants.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;

        public void Set(int sportLeagueLevelId, string name, string abbreviation)
        {
            SportLeagueLevelId = sportLeagueLevelId;
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
