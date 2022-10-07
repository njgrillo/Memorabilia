namespace Memorabilia.Domain.Constants;

public sealed class LeaderType : DomainItemConstant
{
    public static readonly LeaderType AmericanLeagueBattingChampion = new(1, "American League Batting Champion", "AL Batting Champ");
    public static readonly LeaderType AmericanLeagueEarnedRunAverageLeader = new(11, "American League Earned Run Average Leader", "AL ERA Leader");
    public static readonly LeaderType AmericanLeagueHitsLeader = new(18, "American League Hits Leader", "AL Hits Leader");
    public static readonly LeaderType AmericanLeagueHomeRunLeader = new(2, "American League Home Run Leader", "AL HR Leader");
    public static readonly LeaderType AmericanLeagueRunBattedInLeader = new(3, "American League Run Batted In Leader", "AL RBI Leader");
    public static readonly LeaderType AmericanLeagueRunsLeader = new(29, "American League Runs Leader", "AL Runs Leader");
    public static readonly LeaderType AmericanLeagueSavesLeader = new(24, "American League Saves Leader", "AL Saves Leader");
    public static readonly LeaderType AmericanLeagueStolenBaseLeader = new(7, "American League Stolen Base Leader", "AL Stolen Base Leader");
    public static readonly LeaderType AmericanLeagueStrikeoutLeader = new(13, "American League Strikeout Leader", "AL Strikeout Leader");
    public static readonly LeaderType AmericanLeagueTriplesLeader = new(26, "American League Triples Leader", "AL Triples Leader");
    public static readonly LeaderType AmericanLeagueWinsLeader = new(15, "American League Wins Leader", "AL Wins Leader");
    public static readonly LeaderType MajorLeagueBaseballBattingChampion = new(32, "Major League Baseball Batting Champion", "MLB Batting Champ");
    public static readonly LeaderType MajorLeagueBaseballEarnedRunAverageLeader = new(23, "Major League Baseball Earned Run Average Leader", "MLB ERA Leader");
    public static readonly LeaderType MajorLeagueBaseballHitsLeader = new(20, "Major League Baseball Hits Leader", "MLB Hits Leader");
    public static readonly LeaderType MajorLeagueBaseballHomeRunLeader = new(9, "Major League Baseball Home Run Leader", "MLB HR Leader");
    public static readonly LeaderType MajorLeagueBaseballRunsBattedInLeader = new(17, "Major League Baseball Runs Batted In Leader", "MLB RBI Leader");
    public static readonly LeaderType MajorLeagueBaseballRunsLeader = new(31, "Major League Baseball Runs Leader", "MLB Runs Leader");
    public static readonly LeaderType MajorLeagueBaseballSavesLeader = new(22, "Major League Baseball Saves Leader", "MLB Saves Leader");
    public static readonly LeaderType MajorLeagueBaseballStolenBaseLeader = new (33, "Major League Baseball Stolen Base Leader", "MLB Stolen Base Leader");
    public static readonly LeaderType MajorLeagueBaseballStrikeoutLeader = new(21, "Major League Baseball Strikeout Leader", "MLB Strikeout Leader");
    public static readonly LeaderType MajorLeagueBaseballTriplesLeader = new(28, "Major League Baseball Triples Leader", "MLB Triples Leader");
    public static readonly LeaderType MajorLeagueBaseballWinsLeader = new(10, "Major League Baseball Wins Leader", "MLB Wins Leader");
    public static readonly LeaderType NationalLeagueBattingChampion = new(4, "National League Batting Champion", "NL Batting Champ");
    public static readonly LeaderType NationalLeagueHitsLeader = new(19, "National League Hits Leader", "NL Hits Leader");
    public static readonly LeaderType NationalLeagueEarnedRunAverageLeader = new(12, "National League Earned Run Average Leader", "NL ERA Leader");
    public static readonly LeaderType NationalLeagueHomeRunLeader = new(5, "National League Home Run Leader", "NL HR Leader");
    public static readonly LeaderType NationalLeagueRunBattedInLeader = new(6, "National League Run Batted In Leader", "NL RBI Leader");
    public static readonly LeaderType NationalLeagueRunsLeader = new(30, "National League Runs Leader", "NL Runs Leader");
    public static readonly LeaderType NationalLeagueSavesLeader = new(25, "National League Saves Leader", "NL Saves Leader");
    public static readonly LeaderType NationalLeagueStolenBaseLeader = new(8, "National League Stolen Base Leader", "NL Stolen Base Leader");
    public static readonly LeaderType NationalLeagueStrikeoutLeader = new(14, "National League Strikeout Leader", "NL Strikeout Leader");
    public static readonly LeaderType NationalLeagueTriplesLeader = new(27, "National League Triples Leader", "NL Triples Leader");
    public static readonly LeaderType NationalLeagueWinsLeader = new(16, "National League Wins Leader", "NL Wins Leader");

    public static readonly LeaderType[] All =
    {
        AmericanLeagueBattingChampion,
        AmericanLeagueEarnedRunAverageLeader,
        AmericanLeagueHitsLeader,
        AmericanLeagueHomeRunLeader,
        AmericanLeagueRunBattedInLeader,
        AmericanLeagueRunsLeader,
        AmericanLeagueSavesLeader,
        AmericanLeagueStolenBaseLeader,
        AmericanLeagueStrikeoutLeader,
        AmericanLeagueTriplesLeader,
        AmericanLeagueWinsLeader,
        MajorLeagueBaseballBattingChampion,
        MajorLeagueBaseballEarnedRunAverageLeader,
        MajorLeagueBaseballHitsLeader,
        MajorLeagueBaseballHomeRunLeader,
        MajorLeagueBaseballRunsBattedInLeader,
        MajorLeagueBaseballRunsLeader,
        MajorLeagueBaseballSavesLeader,
        MajorLeagueBaseballStolenBaseLeader,
        MajorLeagueBaseballStrikeoutLeader,
        MajorLeagueBaseballTriplesLeader,
        MajorLeagueBaseballWinsLeader,
        NationalLeagueBattingChampion,
        NationalLeagueEarnedRunAverageLeader,
        NationalLeagueHitsLeader,
        NationalLeagueHomeRunLeader,
        NationalLeagueRunBattedInLeader,
        NationalLeagueRunsLeader,
        NationalLeagueSavesLeader,
        NationalLeagueStolenBaseLeader,
        NationalLeagueStrikeoutLeader,
        NationalLeagueTriplesLeader,
        NationalLeagueWinsLeader
    };

    public static readonly LeaderType[] Baseball =
    {
        AmericanLeagueBattingChampion,
        AmericanLeagueEarnedRunAverageLeader,
        AmericanLeagueHitsLeader,
        AmericanLeagueHomeRunLeader,
        AmericanLeagueRunBattedInLeader,
        AmericanLeagueRunsLeader,
        AmericanLeagueSavesLeader,
        AmericanLeagueStolenBaseLeader,
        AmericanLeagueStrikeoutLeader,
        AmericanLeagueTriplesLeader,
        AmericanLeagueWinsLeader,
        MajorLeagueBaseballBattingChampion,
        MajorLeagueBaseballEarnedRunAverageLeader,
        MajorLeagueBaseballHitsLeader,
        MajorLeagueBaseballHomeRunLeader,
        MajorLeagueBaseballRunsBattedInLeader,
        MajorLeagueBaseballRunsLeader,
        MajorLeagueBaseballSavesLeader,
        MajorLeagueBaseballStolenBaseLeader,
        MajorLeagueBaseballStrikeoutLeader,
        MajorLeagueBaseballTriplesLeader,
        MajorLeagueBaseballWinsLeader,
        NationalLeagueBattingChampion,
        NationalLeagueEarnedRunAverageLeader,
        NationalLeagueHitsLeader,
        NationalLeagueHomeRunLeader,
        NationalLeagueRunBattedInLeader,
        NationalLeagueRunsLeader,
        NationalLeagueSavesLeader,
        NationalLeagueStolenBaseLeader,
        NationalLeagueStrikeoutLeader,
        NationalLeagueTriplesLeader,
        NationalLeagueWinsLeader
    };

    private LeaderType(int id, string name, string abbreviation) : base(id, name, abbreviation) { } 

    public static LeaderType Find(int id)
    {
        return All.SingleOrDefault(leaderType => leaderType.Id == id);
    }

    public static LeaderType[] GetAll(int[] sportIds)
    {
        if (!sportIds.Any())
            return All;

        var sports = sportIds.Select(id => Sport.Find(id));
        var leaderTypes = new List<LeaderType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            leaderTypes.AddRange(Baseball);

        return leaderTypes.OrderBy(leaderType => leaderType.Name).ToArray();
    }
}
