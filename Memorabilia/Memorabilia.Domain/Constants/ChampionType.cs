namespace Memorabilia.Domain.Constants
{
    public sealed class ChampionType
    {
        public static readonly ChampionType WorldSeries = new(1, "World Series", "WS");

        public static readonly ChampionType[] All =
        {
            WorldSeries
        };

        private ChampionType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static ChampionType Find(int id)
        {
            return All.SingleOrDefault(championType => championType.Id == id);
        }

        public static ChampionType Find(SportLeagueLevel sportLeagueLevel)
        {
            if (sportLeagueLevel == SportLeagueLevel.MajorLeagueBaseball)
                return WorldSeries;

            return null;
        }
    }
}
