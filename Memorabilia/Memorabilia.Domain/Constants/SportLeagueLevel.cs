using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class SportLeagueLevel
    {
        public static readonly SportLeagueLevel MajorLeagueBaseball = new(1, "Major League Baseball", "MLB");
        public static readonly SportLeagueLevel NationalFootballLeague = new(2, "National Football League", "NFL");
        public static readonly SportLeagueLevel NationalBasketballAssociation = new(3, "National Basketball Association", "NBA");
        public static readonly SportLeagueLevel NationalHockeyLeague = new(4, "National Hockey League", "NHL");

        public static readonly SportLeagueLevel[] All =
        {
            MajorLeagueBaseball,
            NationalFootballLeague,
            NationalBasketballAssociation,
            NationalHockeyLeague
        };

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        private SportLeagueLevel(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public static SportLeagueLevel Find(int id)
        {
            return All.SingleOrDefault(sportLeagueLevel => sportLeagueLevel.Id == id);
        }
    }
}
