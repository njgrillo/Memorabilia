namespace Memorabilia.Domain.Constants;

public sealed class RecordType : DomainItemConstant
{
    public static readonly RecordType AtBats = new(31, "At Bats");
    public static readonly RecordType CompleteGames = new (45, "Complete Games");
    public static readonly RecordType ConsecutiveGamesPlayed = new(23, "Consecutive Games Played");
    public static readonly RecordType ConsecutiveHitlessInningsPitched = new (46, "Consecutive Hitless Innings Pitched");
    public static readonly RecordType ConsecutiveSavesToBeginCareer = new(27, "Consecutive Saves to Begin Career");
    public static readonly RecordType DoublePlaysTurned = new(33, "Double Plays Turned");
    public static readonly RecordType Doubles = new(34, "Doubles");
    public static readonly RecordType EarnedRunAverage = new(16, "Earned Run Average", "ERA");
    public static readonly RecordType ExtraBaseHits = new(1, "Extra Base Hits");
    public static readonly RecordType FastestPitch = new(11, "Fastest Pitch");
    public static readonly RecordType FastestTo400Strikeouts = new (51, "Fastest to 400 Strikeouts");
    public static readonly RecordType Games = new(30, "Games");
    public static readonly RecordType GamesManaged = new(20, "Games Managed");
    public static readonly RecordType GamesPitched = new (53, "Games Pitched");
    public static readonly RecordType GamesStarted = new (44, "Games Started");
    public static readonly RecordType GrandSlamsByPitcher = new(10, "Grand Slams By Pitcher");
    public static readonly RecordType Hits = new (28, "Hits");
    public static readonly RecordType HomeRuns = new (4, "Home Runs");
    public static readonly RecordType HomeRunsHitByPitcher = new (54, "Home Runs Hit by Pitcher");
    public static readonly RecordType InningsPitched = new (43, "Innings Pitched");
    public static readonly RecordType ManagerialLosses = new (19, "Managerial Losses");
    public static readonly RecordType ManagerialWins = new (18, "Managerial Wins");
    public static readonly RecordType MostConsecutiveHitlessAppearances = new (50, "Most Consecutive Hitless Appearances");
    public static readonly RecordType MostConsecutiveOutsViaStrikeout = new (49, "Most Consecutive Outs via Strikeout");
    public static readonly RecordType MostConsecutiveSeasonsWith250Strikeouts = new (40, "Most Consecutive Seasons with 250 Strikeouts");
    public static readonly RecordType MostConsecutiveStrikeoutsInAGame = new (21, "Most Consecutive Strikeouts in a Game");
    public static readonly RecordType MostConsecutiveStrikeoutsWithoutIssuingAWalkToStartSeason = new (55, "Most Consecutive Strikeouts Without Issuing a Walk to Start a Season");
    public static readonly RecordType MostCycles = new (42, "Most Cycles");
    public static readonly RecordType MostHitsInADoubleHeader = new(59, "Most Hits in a Double Header");
    public static readonly RecordType MostHitsInAFourGameSeries = new (48, "Most Hits in a 4 Game Series");
    public static readonly RecordType MostImmaculateInnings = new (38, "Most Immaculate Innings");
    public static readonly RecordType MostRunsBattedInAGame = new(62, "Most RBI in a Game");
    public static readonly RecordType MostRunsBattedInOneInning = new (41, "Most RBI in One Inning");    
    public static readonly RecordType MostStrikeoutsInANineInningGame = new (39, "Most Strikeouts in a 9 Inning Game");
    public static readonly RecordType NationalLeagueOnBasePercentage = new(63, "National League On-Base Percentage", "NL OBP");
    public static readonly RecordType NationalLeagueOnBasePlusSlugging = new(60, "National League On-Base Plus Slugging", "NL OPS");
    public static readonly RecordType NoHitters = new (25, "No Hitters");
    public static readonly RecordType OnBasePercentage = new (6, "On-Base Percentage");    
    public static readonly RecordType OutfieldAssists = new (35, "Outfield Assists");
    public static readonly RecordType PinchHitHomeRuns = new (52, "Pinch Hit Home Runs");
    public static readonly RecordType PlateAppearances = new (32, "Plate Appearances");
    public static readonly RecordType PostseasonInningsPitched = new (9, "Postseason Innings Pitched");
    public static readonly RecordType PutoutsAsOutfielder = new (17, "Putouts as Outfielder");
    public static readonly RecordType Runs = new(13, "Runs");
    public static readonly RecordType RunsBattingIn = new(2, "Runs Batting In", "RBI");
    public static readonly RecordType RunsBattedInByALeadoffHitter = new(47, "RBIs by a Leadoff Hitter");
    public static readonly RecordType Saves = new (24, "Saves");
    public static readonly RecordType Shutouts = new (14, "Shutouts");
    public static readonly RecordType Singles = new (29, "Singles");
    public static readonly RecordType SluggingPercentage = new (7, "Slugging Percentage");
    public static readonly RecordType StolenBases = new (12, "Stolen Bases", "Steals");        
    public static readonly RecordType Strikeouts = new (26, "Strikeouts");
    public static readonly RecordType StrikeoutToWalkRatio = new(36, "Strikeout-to-Walk ratio");
    public static readonly RecordType TotalBases = new(3, "Total Bases");    
    public static readonly RecordType Triples = new(58, "Triples");    
    public static readonly RecordType TwoThousandStrikeoutsInFewestInningsPitched = new (37, "2000 Strikeouts in Fewest Innings Pitched");
    public static readonly RecordType Walks = new(5, "Walks");
    public static readonly RecordType WHIP = new(15, "Walks plus hits per inning pitched", "WHIP");
    public static readonly RecordType Wins = new(22, "Wins");
    public static readonly RecordType WorldSeriesEarnedRunAverage = new(8, "World Series Earned Run Average", "WS ERA");

    public static readonly RecordType[] All =
    {
        AtBats,
        CompleteGames,
        ConsecutiveGamesPlayed,
        ConsecutiveHitlessInningsPitched,
        ConsecutiveSavesToBeginCareer,
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
        OnBasePercentage,
        OutfieldAssists,
        PinchHitHomeRuns,
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

    public static readonly RecordType[] Baseball =
    {
        AtBats,
        CompleteGames,
        ConsecutiveGamesPlayed,
        ConsecutiveHitlessInningsPitched,
        ConsecutiveSavesToBeginCareer,
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
        OnBasePercentage,
        OutfieldAssists,
        PinchHitHomeRuns,
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

    };

    private RecordType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static RecordType Find(int id)
    {
        return All.SingleOrDefault(recordType => recordType.Id == id);
    }

    public static RecordType[] GetAll(params int[] sportIds)
    {
        if (!sportIds.Any())
            return All;

        var sports = sportIds.Select(id => Sport.Find(id));
        var recordTypes = new List<RecordType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            recordTypes.AddRange(Baseball);

        if (sports.Any(sport => sport == Sport.Football))
            recordTypes.AddRange(Football);

        return recordTypes.OrderBy(recordType => recordType.Name).ToArray();
    }
}
