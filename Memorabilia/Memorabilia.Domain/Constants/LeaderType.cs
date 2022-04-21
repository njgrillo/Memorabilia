using Framework.Extension;
using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class LeaderType
    {
        public static readonly LeaderType AmericanLeagueBattingChampion = new(1, "American League Batting Champion", "AL Batting Champ");
        public static readonly LeaderType AmericanLeagueHomeRunLeader = new(2, "American League Home Run Leader", "AL HR Leader");
        public static readonly LeaderType AmericanLeagueRunBattedInLeader = new(3, "American League Run Batted In Leader", "AL RBI Leader");
        public static readonly LeaderType NationalLeagueBattingChampion = new(4, "National League Batting Champion", "NL Batting Champ");
        public static readonly LeaderType NationalLeagueHomeRunLeader = new(5, "National League Home Run Leader", "NL HR Leader");
        public static readonly LeaderType NationalLeagueRunBattedInLeader = new(6, "National League Run Batted In Leader", "NL RBI Leader");

        public static readonly LeaderType[] All =
        {
            AmericanLeagueBattingChampion,
            AmericanLeagueHomeRunLeader,
            AmericanLeagueRunBattedInLeader,
            NationalLeagueBattingChampion,
            NationalLeagueHomeRunLeader,
            NationalLeagueRunBattedInLeader
        };

        private LeaderType(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; }

        public int Id { get; }

        public string Name { get; }

        public static LeaderType Find(int id)
        {
            return All.SingleOrDefault(leaderType => leaderType.Id == id);
        }

        public override string ToString()
        {
            return !Abbreviation.IsNullOrEmpty() ? Abbreviation : Name;
        }
    }
}
