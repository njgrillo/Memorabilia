using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AccomplishmentType
    {
        
        public static readonly AccomplishmentType AllMLBFirstTeam = new(5, "All-MLB First Team", string.Empty);
        public static readonly AccomplishmentType AllMLBSecondTeam = new(4, "All-MLB Second Team", string.Empty);
        public static readonly AccomplishmentType AllWorldBaseballClassicTeam = new(11, "All-World Baseball Classic Team", string.Empty);
        public static readonly AccomplishmentType AmericanLeagueTripleCrown = new(2, "American League Triple Crown", "AL Triple Crown");
        public static readonly AccomplishmentType CombinedNoHitter = new(8, "Combined No Hitter", string.Empty);
        public static readonly AccomplishmentType FourHomeRunsInAGame = new(12, "4 Home Runs in a Game", string.Empty);
        public static readonly AccomplishmentType MajorLeagueBaseballAllCenturyTeam = new(6, "Major League Baseball All-Century Team", string.Empty);
        public static readonly AccomplishmentType MajorLeagueBaseballAllTimeTeam = new(7, "Major League Baseball All-Time Team", string.Empty);
        public static readonly AccomplishmentType NationalLeagueTripleCrown = new(10, "National League Triple Crown", "NL Triple Crown");
        public static readonly AccomplishmentType NoHitter = new(1, "No Hitter", string.Empty);
        public static readonly AccomplishmentType PerfectGame = new(9, "Perfect Game", string.Empty);
        public static readonly AccomplishmentType ThirtyThirtyClub = new(3, "30-30 Club", string.Empty);               

        public static readonly AccomplishmentType[] All =
        {
            AllMLBFirstTeam,
            AllMLBSecondTeam,
            AllWorldBaseballClassicTeam,
            AmericanLeagueTripleCrown,
            CombinedNoHitter,
            FourHomeRunsInAGame,
            MajorLeagueBaseballAllCenturyTeam,
            MajorLeagueBaseballAllTimeTeam,
            NationalLeagueTripleCrown,
            NoHitter,
            PerfectGame,
            ThirtyThirtyClub
        };

        private AccomplishmentType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static AccomplishmentType Find(int id)
        {
            return All.SingleOrDefault(accomplishmentType => accomplishmentType.Id == id);
        }
    }
}
