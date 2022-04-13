using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class AccomplishmentType
    {
        public static readonly AccomplishmentType AllStar = new(3, "All Star", string.Empty);
        public static readonly AccomplishmentType AmericanLeagueBattingChampion = new(4, "American League Batting Champion", "AL Batting Champ");
        public static readonly AccomplishmentType AmericanLeagueHomeRunLeader = new(5, "American League Home Run Leader", "AL HR Leader");
        public static readonly AccomplishmentType AmericanLeagueRunBattedInLeader = new(6, "American League Run Batted In Leader", "AL RBI Leader");
        public static readonly AccomplishmentType NationalLeagueBattingChampion = new(7, "National League Batting Champion", "NL Batting Champ");
        public static readonly AccomplishmentType NationalLeagueHomeRunLeader = new(8, "National League Home Run Leader", "NL HR Leader");
        public static readonly AccomplishmentType NationalLeagueRunBattedInLeader = new(9, "National League Run Batted In Leader", "NL RBI Leader");
        public static readonly AccomplishmentType NoHitter = new(1, "No Hitter", string.Empty);
        public static readonly AccomplishmentType TripleCrown = new(2, "Triple Crown", "TC");    

        public static readonly AccomplishmentType[] All =
        {
            AllStar,
            AmericanLeagueBattingChampion,
            AmericanLeagueHomeRunLeader,
            AmericanLeagueRunBattedInLeader,
            NationalLeagueBattingChampion,
            NationalLeagueHomeRunLeader,
            NationalLeagueRunBattedInLeader,
            NoHitter,
            TripleCrown
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
