namespace Memorabilia.Domain.Constants;

public sealed class RecordType : DomainItemConstant
{
    public static readonly RecordType AtBats = new(31, "At Bats");
    public static readonly RecordType CombinedTackles = new (105, "Combined Tackles");
    public static readonly RecordType CompleteGames = new (45, "Complete Games");
    public static readonly RecordType ConsecutiveGamesPlayed = new(23, "Consecutive Games Played");
    public static readonly RecordType ConsecutiveHitlessInningsPitched = new (46, "Consecutive Hitless Innings Pitched");
    public static readonly RecordType ConsecutiveSavesToBeginCareer = new(27, "Consecutive Saves to Begin Career");
    public static readonly RecordType ConsecutiveStrikeoutsByReliefPitcher = new (84, "Consecutive Strikeouts by a Relief Pitcher");
    public static readonly RecordType DoublePlaysTurned = new(33, "Double Plays Turned");
    public static readonly RecordType Doubles = new(34, "Doubles");
    public static readonly RecordType EarnedRunAverage = new(16, "Earned Run Average", "ERA");
    public static readonly RecordType ExtraBaseHits = new(1, "Extra Base Hits");
    public static readonly RecordType ExtraPointsAttempted = new(72, "Extra Points Attempted");
    public static readonly RecordType ExtraPointsMade = new(71, "Extra Points Made");
    public static readonly RecordType FastestPitch = new(11, "Fastest Pitch");
    public static readonly RecordType FastestTo400Strikeouts = new (51, "Fastest to 400 Strikeouts");
    public static readonly RecordType Games = new(30, "Games");
    public static readonly RecordType GamesManaged = new(20, "Games Managed");
    public static readonly RecordType GamesPitched = new (53, "Games Pitched");
    public static readonly RecordType GamesStarted = new (44, "Games Started");
    public static readonly RecordType GrandSlamsByPitcher = new(10, "Grand Slams By Pitcher");
    public static readonly RecordType HighestAveragePuntingYards = new (69, "Highest Average Punting Yards");
    public static readonly RecordType Hits = new (28, "Hits");
    public static readonly RecordType HomeRuns = new (4, "Home Runs");
    public static readonly RecordType HomeRunsHitByPitcher = new (54, "Home Runs Hit by Pitcher");
    public static readonly RecordType InningsPitched = new (43, "Innings Pitched");
    public static readonly RecordType Interceptions = new (104, "Interceptions");
    public static readonly RecordType LongestRushingTouchdown = new (90, "Longest Rushing Touchdown");
    public static readonly RecordType LongestTenuredCoachForAFranchise = new (83, "Longest-tenured Coach for one Franchise");
    public static readonly RecordType LongestTouchdownPass = new (79, "Longest Touchdown Pass");
    public static readonly RecordType ManagerialLosses = new (19, "Managerial Losses");
    public static readonly RecordType ManagerialWins = new (18, "Managerial Wins");
    public static readonly RecordType MostCareerInterceptionsThrown = new (93, "Most Career Interceptions Thrown");
    public static readonly RecordType MostCareerReceivingYardsTightEnd = new (94, "Most Career Receiving Yards by a Tight End");
    public static readonly RecordType MostCareerReceptionsTightEnd = new (95, "Most Career Receptions by a Tight End");
    public static readonly RecordType MostCareerSafeties = new (98, "Most Career Safeties");
    public static readonly RecordType MostCareerStartsWithOneTeam = new (107, "Most Career Starts with one Team");
    public static readonly RecordType MostConsecutive100YardReceivingGames = new (103, "Most Consecutive 100-yard Receiving Games");
    public static readonly RecordType MostConsecutiveGamesScoring = new (65, "Most Consecutive Games Scoring");
    public static readonly RecordType MostConsecutiveHitlessAppearances = new (50, "Most Consecutive Hitless Appearances");
    public static readonly RecordType MostConsecutiveOutsViaStrikeout = new (49, "Most Consecutive Outs via Strikeout");
    public static readonly RecordType MostConsecutiveSeasonsWith250Strikeouts = new (40, "Most Consecutive Seasons with 250 Strikeouts");
    public static readonly RecordType MostConsecutiveSeasonsWithInterception = new (96, "Most Consecutive Seasons with an Interception");
    public static readonly RecordType MostConsecutiveStartsByQuarterback = new (91, "Most Consecutive Starts by a Quarterback");
    public static readonly RecordType MostConsecutiveStartsByQuarterbackIncludingPlayoffs = new (92, "Most Consecutive Starts by a Quarterback (Including Playoffs)");
    public static readonly RecordType MostConsecutiveStartsByWideReceiver = new (85, "Most Consecutive Starts by a Wide Receiver");
    public static readonly RecordType MostConsecutiveStrikeoutsInAGame = new (21, "Most Consecutive Strikeouts in a Game");
    public static readonly RecordType MostConsecutiveStrikeoutsWithoutIssuingAWalkToStartSeason = new (55, "Most Consecutive Strikeouts Without Issuing a Walk to Start a Season");
    public static readonly RecordType MostCycles = new (42, "Most Cycles");
    public static readonly RecordType MostFiftyPlusYearFieldGoalsInAGame = new (66, "Most 50+ Yard Field Goals in a Game");
    public static readonly RecordType MostGamesPlayed = new (64, "Most Games Played");
    public static readonly RecordType MostHitsInADoubleHeader = new(59, "Most Hits in a Double Header");
    public static readonly RecordType MostHitsInAFourGameSeries = new (48, "Most Hits in a 4 Game Series");
    public static readonly RecordType MostImmaculateInnings = new (38, "Most Immaculate Innings");
    public static readonly RecordType MostInterceptionsReturnedForTouchdownInASeason = new (99, "Most Interceptions Returned for Touchdown in a Season");    
    public static readonly RecordType MostInterceptionsReturnedForTouchdownInASeasonByARookie = new (68, "Most Interceptions Returned for Touchdown in a Season by a Rookie");    
    public static readonly RecordType MostPassesInterceptedInASingleGame = new (86, "Most Passes Intercepted in a Single Game");
    public static readonly RecordType MostReceivingYards = new(102, "Most Receiving Yards");
    public static readonly RecordType MostRunsBattedInAGame = new(62, "Most RBI in a Game");
    public static readonly RecordType MostRunsBattedInOneInning = new (41, "Most RBI in One Inning");
    public static readonly RecordType MostSeasonsLeadingLeagueInPointsScored = new(100, "Most Seasons Leading League in Points Scored");
    public static readonly RecordType MostSeasonsLeadingLeagueInSacks = new(97, "Most Seasons Leading League in Sacks");
    public static readonly RecordType MostSeasonsLeadingLeagueInTouchdowns = new(101, "Most Seasons Leading League in Touchdowns");
    public static readonly RecordType MostStrikeoutsInANineInningGame = new (39, "Most Strikeouts in a 9 Inning Game");
    public static readonly RecordType NationalLeagueOnBasePercentage = new(63, "National League On-Base Percentage", "NL OBP");
    public static readonly RecordType NationalLeagueOnBasePlusSlugging = new(60, "National League On-Base Plus Slugging", "NL OPS");
    public static readonly RecordType NoHitters = new (25, "No Hitters");
    public static readonly RecordType OldestPlayerToTriple = new (82, "Oldest Player to hit a Triple");    
    public static readonly RecordType OnBasePercentage = new (6, "On-Base Percentage");    
    public static readonly RecordType OutfieldAssists = new (35, "Outfield Assists");
    public static readonly RecordType PassesDefended = new (67, "Passes Defended");
    public static readonly RecordType PassingAttempts = new (75, "Passing Attempts");
    public static readonly RecordType PassingCompletions = new (76, "Passing Completions");
    public static readonly RecordType PassingTouchdowns = new (77, "Passing Touchdowns");
    public static readonly RecordType PassingYards = new (80, "Passing Yards");
    public static readonly RecordType PinchHitHomeRuns = new (52, "Pinch Hit Home Runs");
    public static readonly RecordType PinchRunningAppearances = new (81, "Pinch Running Appearances");
    public static readonly RecordType PlateAppearances = new (32, "Plate Appearances");
    public static readonly RecordType PostseasonInningsPitched = new (9, "Postseason Innings Pitched");
    public static readonly RecordType PutoutsAsOutfielder = new (17, "Putouts as Outfielder");
    public static readonly RecordType QuarterbackWins = new (74, "Quarterback Wins");
    public static readonly RecordType Runs = new(13, "Runs");
    public static readonly RecordType RunsBattingIn = new(2, "Runs Batting In", "RBI");
    public static readonly RecordType RunsBattedInByALeadoffHitter = new(47, "RBIs by a Leadoff Hitter");
    public static readonly RecordType RushingYards = new (87, "Rushing Yards");
    public static readonly RecordType RushingYardsAsARookie = new (88, "Rushing Yards as a Rookie");
    public static readonly RecordType RushingYardsInAPlayoffGame = new (89, "Rushing Yards in a Playoff Game");
    public static readonly RecordType Sacked = new (78, "Sacked");
    public static readonly RecordType Saves = new (24, "Saves");
    public static readonly RecordType SeasonsPlayed = new (70, "Seasons Played");
    public static readonly RecordType Shutouts = new (14, "Shutouts");
    public static readonly RecordType Singles = new (29, "Singles");
    public static readonly RecordType SluggingPercentage = new (7, "Slugging Percentage");
    public static readonly RecordType StolenBases = new (12, "Stolen Bases", "Steals");        
    public static readonly RecordType Strikeouts = new (26, "Strikeouts");
    public static readonly RecordType StrikeoutToWalkRatio = new(36, "Strikeout-to-Walk ratio");
    public static readonly RecordType Tackles = new(106, "Tackles");    
    public static readonly RecordType TotalBases = new(3, "Total Bases");    
    public static readonly RecordType TouchdownPassesInAGame = new(73, "Touchdown Passes in a Game");    
    public static readonly RecordType Triples = new(58, "Triples");    
    public static readonly RecordType TwoThousandStrikeoutsInFewestInningsPitched = new (37, "2000 Strikeouts in Fewest Innings Pitched");
    public static readonly RecordType Walks = new(5, "Walks");
    public static readonly RecordType WHIP = new(15, "Walks plus hits per inning pitched", "WHIP");
    public static readonly RecordType Wins = new(22, "Wins");
    public static readonly RecordType WorldSeriesEarnedRunAverage = new(8, "World Series Earned Run Average", "WS ERA");

    public static readonly RecordType[] All =
    {
        AtBats,
        CombinedTackles,
        CompleteGames,
        ConsecutiveGamesPlayed,
        ConsecutiveHitlessInningsPitched,
        ConsecutiveSavesToBeginCareer,
        ConsecutiveStrikeoutsByReliefPitcher,
        DoublePlaysTurned,
        Doubles,
        EarnedRunAverage,
        ExtraBaseHits,
        ExtraPointsAttempted,
        ExtraPointsMade,
        FastestPitch,
        FastestTo400Strikeouts,
        Games,
        GamesManaged,
        GamesPitched,
        GamesStarted,
        GrandSlamsByPitcher,
        HighestAveragePuntingYards,
        Hits,
        HomeRuns,
        HomeRunsHitByPitcher,
        InningsPitched,
        Interceptions,
        LongestRushingTouchdown,
        LongestTenuredCoachForAFranchise,
        LongestTouchdownPass,
        ManagerialLosses,
        ManagerialWins,
        MostCareerInterceptionsThrown,
        MostCareerReceivingYardsTightEnd,
        MostCareerReceptionsTightEnd,
        MostCareerSafeties,
        MostCareerStartsWithOneTeam,
        MostConsecutive100YardReceivingGames,
        MostConsecutiveGamesScoring,
        MostConsecutiveHitlessAppearances,
        MostConsecutiveOutsViaStrikeout,
        MostConsecutiveSeasonsWith250Strikeouts,
        MostConsecutiveSeasonsWithInterception,
        MostConsecutiveStartsByQuarterback,
        MostConsecutiveStartsByQuarterbackIncludingPlayoffs,
        MostConsecutiveStartsByWideReceiver,
        MostConsecutiveStrikeoutsInAGame,
        MostConsecutiveStrikeoutsWithoutIssuingAWalkToStartSeason,
        MostCycles,
        MostFiftyPlusYearFieldGoalsInAGame,
        MostGamesPlayed,
        MostHitsInADoubleHeader,
        MostHitsInAFourGameSeries,
        MostImmaculateInnings,
        MostInterceptionsReturnedForTouchdownInASeason,
        MostInterceptionsReturnedForTouchdownInASeasonByARookie,
        MostPassesInterceptedInASingleGame,
        MostReceivingYards,
        MostRunsBattedInAGame,
        MostRunsBattedInOneInning,
        MostSeasonsLeadingLeagueInPointsScored,
        MostSeasonsLeadingLeagueInSacks,
        MostSeasonsLeadingLeagueInTouchdowns,
        MostStrikeoutsInANineInningGame,
        NationalLeagueOnBasePercentage,
        NationalLeagueOnBasePlusSlugging,
        NoHitters,
        OldestPlayerToTriple,
        OnBasePercentage,
        OutfieldAssists,
        PassesDefended,
        PassingAttempts,
        PassingCompletions,
        PassingTouchdowns,
        PassingYards,
        PinchHitHomeRuns,
        PinchRunningAppearances,
        PlateAppearances,
        PostseasonInningsPitched,
        PutoutsAsOutfielder,
        QuarterbackWins,
        Runs,
        RunsBattingIn,
        RunsBattedInByALeadoffHitter,
        RushingYards,
        RushingYardsAsARookie,
        RushingYardsInAPlayoffGame,
        Sacked,
        Saves,
        SeasonsPlayed,
        Shutouts,
        Singles,
        SluggingPercentage,
        StolenBases,
        Strikeouts,
        StrikeoutToWalkRatio,
        Tackles,
        TotalBases,
        TouchdownPassesInAGame,
        Triples,
        TwoThousandStrikeoutsInFewestInningsPitched,
        Walks,
        Wins,
        WHIP,
        WorldSeriesEarnedRunAverage
    };

    public static readonly RecordType[] Baseball =
    {
        AtBats,
        CompleteGames,
        ConsecutiveGamesPlayed,
        ConsecutiveHitlessInningsPitched,
        ConsecutiveSavesToBeginCareer,
        ConsecutiveStrikeoutsByReliefPitcher,
        DoublePlaysTurned,
        Doubles,
        EarnedRunAverage,
        ExtraBaseHits,
        FastestPitch,
        FastestTo400Strikeouts,
        Games,
        GamesManaged,
        GamesPitched,
        GamesStarted,
        GrandSlamsByPitcher,
        Hits,
        HomeRuns,
        HomeRunsHitByPitcher,
        InningsPitched,
        LongestTenuredCoachForAFranchise,
        ManagerialLosses,
        ManagerialWins,
        MostConsecutiveHitlessAppearances,
        MostConsecutiveOutsViaStrikeout,
        MostConsecutiveSeasonsWith250Strikeouts,
        MostConsecutiveStrikeoutsInAGame,
        MostConsecutiveStrikeoutsWithoutIssuingAWalkToStartSeason,
        MostCycles,
        MostHitsInADoubleHeader,
        MostHitsInAFourGameSeries,
        MostImmaculateInnings,
        MostRunsBattedInAGame,
        MostRunsBattedInOneInning,
        MostStrikeoutsInANineInningGame,
        NationalLeagueOnBasePercentage,
        NationalLeagueOnBasePlusSlugging,
        NoHitters,
        OldestPlayerToTriple,
        OnBasePercentage,
        OutfieldAssists,
        PinchHitHomeRuns,
        PinchRunningAppearances,
        PlateAppearances,
        PostseasonInningsPitched,
        PutoutsAsOutfielder,
        Runs,
        RunsBattingIn,
        RunsBattedInByALeadoffHitter,
        Saves,
        Shutouts,
        Singles,
        SluggingPercentage,
        StolenBases,
        Strikeouts,
        StrikeoutToWalkRatio,
        TotalBases,
        Triples,
        TwoThousandStrikeoutsInFewestInningsPitched,
        Walks,
        Wins,
        WHIP,
        WorldSeriesEarnedRunAverage
    };

    public static readonly RecordType[] Football =
    {
        CombinedTackles,
        ExtraPointsAttempted,
        ExtraPointsMade,
        HighestAveragePuntingYards,
        Interceptions,
        LongestRushingTouchdown,
        LongestTouchdownPass,
        MostCareerInterceptionsThrown,
        MostCareerReceivingYardsTightEnd,
        MostCareerReceptionsTightEnd,
        MostCareerSafeties,
        MostCareerStartsWithOneTeam,
        MostConsecutive100YardReceivingGames,
        MostConsecutiveGamesScoring,
        MostConsecutiveSeasonsWithInterception,
        MostConsecutiveStartsByQuarterback,
        MostConsecutiveStartsByQuarterbackIncludingPlayoffs,
        MostConsecutiveStartsByWideReceiver,
        MostFiftyPlusYearFieldGoalsInAGame,
        MostGamesPlayed,
        MostInterceptionsReturnedForTouchdownInASeason,
        MostInterceptionsReturnedForTouchdownInASeasonByARookie,
        MostPassesInterceptedInASingleGame,
        MostReceivingYards,
        MostSeasonsLeadingLeagueInPointsScored,
        MostSeasonsLeadingLeagueInSacks,
        MostSeasonsLeadingLeagueInTouchdowns,
        PassesDefended,
        PassingAttempts,
        PassingCompletions,
        PassingTouchdowns,
        PassingYards,
        QuarterbackWins,
        RushingYards,
        RushingYardsAsARookie,
        RushingYardsInAPlayoffGame,
        Sacked,
        SeasonsPlayed,
        Tackles,
        TouchdownPassesInAGame
    };

    private RecordType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static RecordType Find(int id)
    {
        return All.SingleOrDefault(recordType => recordType.Id == id);
    }

    public static RecordType[] GetAll(params Sport[] sports)
    {
        if (!sports.Any())
            return All;

        var recordTypes = new List<RecordType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            recordTypes.AddRange(Baseball);

        if (sports.Any(sport => sport == Sport.Football))
            recordTypes.AddRange(Football);

        return recordTypes.OrderBy(recordType => recordType.Name).ToArray();
    }
}
