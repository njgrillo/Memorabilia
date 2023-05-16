namespace Memorabilia.Domain.Constants;

public sealed class LeaderType : DomainItemConstant
{
    public static readonly LeaderType AAFCReceivingYards = new(61, "AAFC Receiving Yards");
    public static readonly LeaderType AAFCReceptions = new(62, "AAFC Receptions");
    public static readonly LeaderType AAFCRushingTouchdowns = new(65, "AAFC Rushing Touchdowns");
    public static readonly LeaderType AAFCRushingYards = new(64, "AAFC Rushing Yards");
    public static readonly LeaderType ABAScoringChampion = new (77, "ABA Scoring Champion");
    public static readonly LeaderType ABLScoring = new (73, "ABL Scoring");
    public static readonly LeaderType AFLCompletionPercentage = new(58, "AFL Completion Percentage");
    public static readonly LeaderType AFLInterceptions = new(67, "AFL Interceptions");
    public static readonly LeaderType AFLPasserRating = new(57, "AFL Passer Rating");
    public static readonly LeaderType AFLPassingTouchdowns = new(54, "AFL Passing Touchdowns");
    public static readonly LeaderType AFLPassingYards = new(53, "AFL Passing Yards");
    public static readonly LeaderType AFLReceivingTouchdowns = new(42, "AFL Receiving Touchdowns");
    public static readonly LeaderType AFLReceivingYards = new(40, "AFL Receiving Yards");
    public static readonly LeaderType AFLReceptions = new(41, "AFL Receptions");
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
    public static readonly LeaderType BAAScoringChampion = new (75, "BAA Scoring Champion");    
    public static readonly LeaderType CompletionPercentage = new (36, "NFL Completion Percentage");    
    public static readonly LeaderType ForcedFumbles = new (60, "NFL Forced Fumbles");    
    public static readonly LeaderType Interceptions = new (43, "NFL Interceptions");    
    public static readonly LeaderType KickoffReturnYards = new (56, "NFL Kickoff Return Yards");    
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
    public static readonly LeaderType NationalLeagueAssists = new(55, "National League Assists", "NL Assists");
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
    public static readonly LeaderType NBAAssists = new(74, "NBA Assists");
    public static readonly LeaderType NBABlocks = new(78, "NBA Blocks");
    public static readonly LeaderType NBAReboundingLeader = new(71, "NBA Rebounding Leader");
    public static readonly LeaderType NBAScoringChampion = new(70, "NBA Scoring Champion");
    public static readonly LeaderType NBASteals = new(76, "NBA Steals");
    public static readonly LeaderType NBLScoring = new(72, "NBL Scoring");
    public static readonly LeaderType NBLScoringChampion = new(69, "NBL Scoring Champion");
    public static readonly LeaderType NCAADivisionIScoringLeader = new (68, "NCAA Division I Scoring Leader");
    public static readonly LeaderType PasserRating = new (46, "NFL Passer Rating");
    public static readonly LeaderType PassingTouchdowns = new (45, "NFL Passing Touchdowns");
    public static readonly LeaderType PassingYards = new (44, "NFL Passing Yards");
    public static readonly LeaderType PuntingAverage = new (48, "NFL Punting Average");
    public static readonly LeaderType PuntingYards = new (49, "NFL Punting Yards");
    public static readonly LeaderType PuntReturnYards = new (79, "NFL Punt Return Yards");
    public static readonly LeaderType ReceivingTouchdowns = new (52, "NFL Receiving Touchdowns");
    public static readonly LeaderType ReceivingYards = new (50, "NFL Receiving Yards");
    public static readonly LeaderType Receptions = new (51, "NFL Receptions");
    public static readonly LeaderType Rushes = new (66, "NFL Rushes");
    public static readonly LeaderType RushingTouchdowns = new (37, "NFL Rushing Touchdowns");
    public static readonly LeaderType RushingYards = new (38, "NFL Rushing Yards");
    public static readonly LeaderType Sacks = new (59, "NFL Sacks");
    public static readonly LeaderType Scoring = new (39, "NFL Scoring");
    public static readonly LeaderType Tackles = new (63, "NFL Tackles");

    public static LeaderType[] All
        => Baseball.Union(Basketball)
                   .Union(Football)
                   .Distinct()
                   .ToArray();

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
        NationalLeagueAssists,
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

    public static readonly LeaderType[] Basketball =
    {
        ABAScoringChampion,
        ABLScoring,
        BAAScoringChampion,
        NBAAssists,
        NBABlocks,
        NBAReboundingLeader,
        NBAScoringChampion,
        NBASteals,
        NBLScoring,
        NBLScoringChampion,
        NCAADivisionIScoringLeader
    };

    public static readonly LeaderType[] Football =
    {
        AAFCReceivingYards,
        AAFCReceptions,
        AAFCRushingTouchdowns,
        AAFCRushingYards,
        AFLCompletionPercentage,
        AFLInterceptions,
        AFLPasserRating,
        AFLPassingTouchdowns,
        AFLPassingYards,
        AFLReceivingTouchdowns,
        AFLReceivingYards,
        AFLReceptions,
        CompletionPercentage,
        ForcedFumbles,
        Interceptions,
        KickoffReturnYards,
        PasserRating,
        PassingTouchdowns,
        PassingYards,
        PuntingAverage,
        PuntingYards,
        PuntReturnYards,
        ReceivingTouchdowns,
        ReceivingYards,
        Receptions,
        Rushes,
        RushingTouchdowns,
        RushingYards,
        Sacks,
        Scoring,
        Tackles
    };

    private LeaderType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { } 

    public static LeaderType Find(int id)
        => All.SingleOrDefault(leaderType => leaderType.Id == id);

    public static LeaderType[] GetAll(params Sport[] sports)
    {
        if (!sports.Any())
            return All;

        var leaderTypes = new List<LeaderType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            leaderTypes.AddRange(Baseball);

        if (sports.Any(sport => sport == Sport.Basketball))
            leaderTypes.AddRange(Basketball);

        if (sports.Any(sport => sport == Sport.Football))
            leaderTypes.AddRange(Football);

        return leaderTypes.OrderBy(leaderType => leaderType.Name).ToArray();
    }

    public override string ToString()
        => Name;
}
