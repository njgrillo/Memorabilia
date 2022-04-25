using Framework.Extension;
using System.Linq;

namespace Memorabilia.Domain.Constants
{
    public sealed class LeaderType
    {
        public static readonly LeaderType AmericanLeagueBattingChampion = new(1, "American League Batting Champion", "AL Batting Champ");
        public static readonly LeaderType AmericanLeagueEarnedRunAverageLeader = new(11, "American League Earned Run Average Leader", "AL ERA Leader");
        public static readonly LeaderType AmericanLeagueHitsLeader = new(18, "American League Hits Leader", "AL Hits Leader");
        public static readonly LeaderType AmericanLeagueHomeRunLeader = new(2, "American League Home Run Leader", "AL HR Leader");
        public static readonly LeaderType AmericanLeagueRunBattedInLeader = new(3, "American League Run Batted In Leader", "AL RBI Leader");
        public static readonly LeaderType AmericanLeagueStolenBaseLeader = new(7, "American League Stolen Base Leader", "AL Stolen Base Leader");
        public static readonly LeaderType AmericanLeagueStrikeoutLeader = new(13, "American League Strikeout Leader", "AL Strikeout Leader");
        public static readonly LeaderType AmericanLeagueWinsLeader = new(15, "American League Wins Leader", "AL Wins Leader");
        public static readonly LeaderType MajorLeagueBaseballHitsLeader = new(20, "Major League Baseball Hits Leader", "MLB Hits Leader");
        public static readonly LeaderType MajorLeagueBaseballHomeRunLeader = new(9, "Major League Baseball Home Run Leader", "MLB HR Leader");
        public static readonly LeaderType MajorLeagueBaseballRunsBattedInLeader = new(17, "Major League Baseball Runs Batted In Leader", "MLB RBI Leader");
        public static readonly LeaderType MajorLeagueBaseballWinsLeader = new(10, "Major League Baseball Wins Leader", "MLB Wins Leader");
        public static readonly LeaderType NationalLeagueBattingChampion = new(4, "National League Batting Champion", "NL Batting Champ");
        public static readonly LeaderType NationalLeagueHitsLeader = new(19, "National League Hits Leader", "NL Hits Leader");
        public static readonly LeaderType NationalLeagueEarnedRunAverageLeader = new(12, "National League Earned Run Average Leader", "NL ERA Leader");
        public static readonly LeaderType NationalLeagueHomeRunLeader = new(5, "National League Home Run Leader", "NL HR Leader");
        public static readonly LeaderType NationalLeagueRunBattedInLeader = new(6, "National League Run Batted In Leader", "NL RBI Leader");
        public static readonly LeaderType NationalLeagueStolenBaseLeader = new(8, "National League Stolen Base Leader", "NL Stolen Base Leader");
        public static readonly LeaderType NationalLeagueStrikeoutLeader = new(14, "National League Strikeout Leader", "NL Strikeout Leader");
        public static readonly LeaderType NationalLeagueWinsLeader = new(16, "National League Wins Leader", "NL Wins Leader");

        public static readonly LeaderType[] All =
        {
            AmericanLeagueBattingChampion,
            AmericanLeagueEarnedRunAverageLeader,
            AmericanLeagueHitsLeader,
            AmericanLeagueHomeRunLeader,
            AmericanLeagueRunBattedInLeader,
            AmericanLeagueStolenBaseLeader,
            AmericanLeagueStrikeoutLeader,
            AmericanLeagueWinsLeader,
            MajorLeagueBaseballHitsLeader,
            MajorLeagueBaseballHomeRunLeader,
            MajorLeagueBaseballRunsBattedInLeader,
            MajorLeagueBaseballWinsLeader,
            NationalLeagueBattingChampion,
            NationalLeagueEarnedRunAverageLeader,
            NationalLeagueHitsLeader,
            NationalLeagueHomeRunLeader,
            NationalLeagueRunBattedInLeader,
            NationalLeagueStolenBaseLeader,
            NationalLeagueStrikeoutLeader,
            NationalLeagueWinsLeader
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
