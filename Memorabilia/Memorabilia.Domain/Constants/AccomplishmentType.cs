using Memorabilia.Domain.Entities;

namespace Memorabilia.Domain.Constants;

public sealed class AccomplishmentType : DomainItemConstant
{    
    public static readonly AccomplishmentType AFLAllTimeTeam = new (39, "AFL All-Time Team");
    public static readonly AccomplishmentType AllAmerican = new (34, "All-American");
    public static readonly AccomplishmentType AllMLBFirstTeam = new(5, "All-MLB First Team");
    public static readonly AccomplishmentType AllMLBSecondTeam = new(4, "All-MLB Second Team");
    public static readonly AccomplishmentType AllPro = new(45, "All-Pro");
    public static readonly AccomplishmentType AllRookieTeam = new(46, "All-Rookie Team");
    public static readonly AccomplishmentType AllWorldBaseballClassicTeam = new(11, "All-World Baseball Classic Team");
    public static readonly AccomplishmentType AmericanLeagueTripleCrown = new(2, "American League Triple Crown", "AL Triple Crown");
    public static readonly AccomplishmentType BostonPatriotsAll1960sTeam = new(71, "Boston Patriots All-1960s Team");
    public static readonly AccomplishmentType CFB150GreatestCollegeFootballPlayerEver = new (69, "CFB150 Greatest College Football Player Ever");
    public static readonly AccomplishmentType CombinedNoHitter = new(8, "Combined No Hitter");
    public static readonly AccomplishmentType ConsensusAllAmerican = new (28, "Consensus All-American");
    public static readonly AccomplishmentType DenverBroncos50thAnniversaryTeam = new (48, "Denver Broncos 50th Anniversary Team");
    public static readonly AccomplishmentType DetroitLions75thAnniversaryTeam = new (49, "Detroit Lions 75th Anniversary Team");
    public static readonly AccomplishmentType DetroitLionsAllTimeTeam = new (50, "Detroit Lions All-Time Team");
    public static readonly AccomplishmentType EightyGreatestRedskins = new (30, "80 Greatest Redskins");
    public static readonly AccomplishmentType FiftyAnniversaryAllTimeTeam = new (55, "50th Anniversary All-Time Team");
    public static readonly AccomplishmentType FirstTeamAllAFL = new (37, "First-team All-AFL");
    public static readonly AccomplishmentType FirstTeamAllAmerican = new (41, "First-team All-American");
    public static readonly AccomplishmentType FirstTeamAllBigEight = new (68, "First-team All-Big Eight");
    public static readonly AccomplishmentType FirstTeamAllBigTen = new (42, "First-team All-Big Ten");
    public static readonly AccomplishmentType FirstTeamAllPac10 = new (60, "First-team All-Pac-10");
    public static readonly AccomplishmentType FirstTeamAllPro = new (25, "First-team All-Pro");
    public static readonly AccomplishmentType FirstTeamLittleAllAmerican = new (70, "First-team Little All-American");
    public static readonly AccomplishmentType FortyFortyClub = new(18, "40-40 Club");
    public static readonly AccomplishmentType FourHomeRunsInAGame = new(12, "4 Home Runs in a Game");
    public static readonly AccomplishmentType HitForTheCycle = new(13, "Hit for the Cycle");
    public static readonly AccomplishmentType ImmaculateInning = new(14, "Immaculate Inning");
    public static readonly AccomplishmentType MajorLeagueBaseballAllCenturyTeam = new(6, "Major League Baseball All-Century Team");
    public static readonly AccomplishmentType MajorLeagueBaseballAllTimeTeam = new(7, "Major League Baseball All-Time Team");
    public static readonly AccomplishmentType NationalLeagueTripleCrown = new(10, "National League Triple Crown", "NL Triple Crown");
    public static readonly AccomplishmentType NewEnglandPatriotsAll1980sTeam = new(58, "New England Patriots All-1980s Team");
    public static readonly AccomplishmentType NewEnglandPatriotsAll2000sTeam = new(63, "New England Patriots All-2000s Team");
    public static readonly AccomplishmentType NewEnglandPatriotsAll2010sTeam = new(64, "New England Patriots All-2010s Team");
    public static readonly AccomplishmentType NewEnglandPatriotsAllDynastyTeam = new(66, "New England Patriots All-Dynasty Team");
    public static readonly AccomplishmentType NewEnglandPatriots35thAnniversaryTeam = new (72, "New England Patriots 35th Anniversary Team");
    public static readonly AccomplishmentType NewEnglandPatriots50thAnniversaryTeam = new (65, "New England Patriots 50th Anniversary Team");
    public static readonly AccomplishmentType NineteenEightiesAllDecadeTeam = new(40, "1980s All-Decade Team");
    public static readonly AccomplishmentType NineteenFiftiesAllDecadeTeam = new(54, "1950s All-Decade Team");
    public static readonly AccomplishmentType NineteenFortiesAllDecadeTeam = new(53, "1940s All-Decade Team");
    public static readonly AccomplishmentType NineteenNinetiesAllDecadeTeam = new(31, "1990s All-Decade Team");
    public static readonly AccomplishmentType NineteenSeventiesAllDecadeTeam = new(57, "1970s All-Decade Team");
    public static readonly AccomplishmentType NineteenSixtiesAllDecadeTeam = new(27, "1960s All-Decade Team");    
    public static readonly AccomplishmentType NineteenThirtiesAllDecadeTeam = new(52, "1930s All-Decade Team"); 
    public static readonly AccomplishmentType NoHitter = new(1, "No Hitter");
    public static readonly AccomplishmentType OneHundredAnniversaryAllTimeTeam = new(33, "100th Anniversary All-Time Team");
    public static readonly AccomplishmentType OneHundredGreatestBearsOfAllTime = new(44, "100 Greatest Bears of All-Time");
    public static readonly AccomplishmentType PerfectGame = new(9, "Perfect Game");
    public static readonly AccomplishmentType PFWAAllRookieTeam = new(29, "PFWA All-Rookie Team");
    public static readonly AccomplishmentType PhiladelphiaEagles75thAnniversaryTeam = new (56, "Philadelphia Eagles 75th Anniversary Team");
    public static readonly AccomplishmentType PittsburghSteelersAllTimeTeam = new (59, "Pittsburgh Steelers All-Time Team");
    public static readonly AccomplishmentType PrideOfTheJaguars = new (61, "Pride of the Jaguars");
    public static readonly AccomplishmentType PrideOfTheLions = new (51, "Pride of the Lions");
    public static readonly AccomplishmentType SecondTeamAllAFL = new(38, "Second-team All-AFL");
    public static readonly AccomplishmentType SecondTeamAllAmerican = new(35, "Second-team All-American");    
    public static readonly AccomplishmentType SecondTeamAllBigTen = new(43, "Second-team All-Big Ten");    
    public static readonly AccomplishmentType SecondTeamAllPro = new(26, "Second-team All-Pro");
    public static readonly AccomplishmentType SeventyFifthAnniversaryAllTimeTeam = new(36, "75th Anniversary All-Time Team");
    public static readonly AccomplishmentType ThirtyThirtyClub = new(3, "30-30 Club");
    public static readonly AccomplishmentType ToppsAllStarRookieTeam = new (67, "Topps All-Star Rookie Team");
    public static readonly AccomplishmentType TwoBasesLoadedTriplesInAGame = new(24, "2 Bases Loaded Triples in a Game");
    public static readonly AccomplishmentType TwoGrandSlamsInOneInning = new(16, "2 Grand Slams in One Inning");    
    public static readonly AccomplishmentType TwoThousandsAllDecadeTeam = new(32, "2000s All-Decade Team");    
    public static readonly AccomplishmentType TwoThousandTensAllDecadeTeam = new(62, "2010s All-Decade Team");    
    public static readonly AccomplishmentType UnassistedTriplePlay = new(17, "Unassisted Triple Play");
    public static readonly AccomplishmentType WashingtonCommandersNinetyGreatest = new (47, "Washington Commanders 90 Greatest");
      
    public static readonly AccomplishmentType[] All =
    {
        AFLAllTimeTeam,
        AllAmerican,
        AllMLBFirstTeam,
        AllMLBSecondTeam,
        AllPro,
        AllRookieTeam,
        AllWorldBaseballClassicTeam,
        AmericanLeagueTripleCrown,
        BostonPatriotsAll1960sTeam,
        CFB150GreatestCollegeFootballPlayerEver,
        CombinedNoHitter,
        ConsensusAllAmerican,
        DenverBroncos50thAnniversaryTeam,
        DetroitLions75thAnniversaryTeam,
        DetroitLionsAllTimeTeam,
        EightyGreatestRedskins,
        FiftyAnniversaryAllTimeTeam,
        FirstTeamAllAFL,
        FirstTeamAllAmerican,
        FirstTeamAllBigEight,
        FirstTeamAllBigTen,
        FirstTeamAllPac10,
        FirstTeamAllPro,
        FirstTeamLittleAllAmerican,
        FortyFortyClub,
        FourHomeRunsInAGame,
        HitForTheCycle,
        ImmaculateInning,
        MajorLeagueBaseballAllCenturyTeam,
        MajorLeagueBaseballAllTimeTeam,
        NationalLeagueTripleCrown,
        NewEnglandPatriotsAll1980sTeam,
        NewEnglandPatriotsAll2000sTeam,
        NewEnglandPatriotsAll2010sTeam,
        NewEnglandPatriotsAllDynastyTeam,
        NewEnglandPatriots35thAnniversaryTeam,
        NewEnglandPatriots50thAnniversaryTeam,
        NineteenEightiesAllDecadeTeam,
        NineteenFiftiesAllDecadeTeam,
        NineteenFortiesAllDecadeTeam,
        NineteenNinetiesAllDecadeTeam,
        NineteenSeventiesAllDecadeTeam,
        NineteenSixtiesAllDecadeTeam,
        NineteenThirtiesAllDecadeTeam,
        NoHitter,
        OneHundredAnniversaryAllTimeTeam,
        OneHundredGreatestBearsOfAllTime,
        PerfectGame,
        PFWAAllRookieTeam,
        PhiladelphiaEagles75thAnniversaryTeam,
        PittsburghSteelersAllTimeTeam,
        PrideOfTheJaguars,
        PrideOfTheLions,
        SecondTeamAllAFL,
        SecondTeamAllAmerican,
        SecondTeamAllBigTen,
        SecondTeamAllPro,
        SeventyFifthAnniversaryAllTimeTeam,
        ThirtyThirtyClub,
        ToppsAllStarRookieTeam,
        TwoBasesLoadedTriplesInAGame,
        TwoGrandSlamsInOneInning,
        TwoThousandsAllDecadeTeam,
        TwoThousandTensAllDecadeTeam,
        UnassistedTriplePlay,
        WashingtonCommandersNinetyGreatest
    };

    public static readonly AccomplishmentType[] Baseball =
    {
        AllMLBFirstTeam,
        AllMLBSecondTeam,
        AllWorldBaseballClassicTeam,
        AmericanLeagueTripleCrown,
        CombinedNoHitter,
        FortyFortyClub,
        FourHomeRunsInAGame,
        HitForTheCycle,
        ImmaculateInning,
        MajorLeagueBaseballAllCenturyTeam,
        MajorLeagueBaseballAllTimeTeam,
        NationalLeagueTripleCrown,
        NoHitter,
        PerfectGame,
        ThirtyThirtyClub,
        ToppsAllStarRookieTeam,
        TwoBasesLoadedTriplesInAGame,
        TwoGrandSlamsInOneInning,
        UnassistedTriplePlay
    };

    public static readonly AccomplishmentType[] DateAccomplishment =
    {
        CombinedNoHitter,
        FourHomeRunsInAGame,
        HitForTheCycle,
        ImmaculateInning,
        NoHitter,
        PerfectGame,
        TwoBasesLoadedTriplesInAGame,
        TwoGrandSlamsInOneInning,
        UnassistedTriplePlay
    };

    public static readonly AccomplishmentType[] Football =
    {
        AFLAllTimeTeam,
        AllAmerican,
        AllPro,
        AllRookieTeam,
        BostonPatriotsAll1960sTeam,
        CFB150GreatestCollegeFootballPlayerEver,
        ConsensusAllAmerican,
        DenverBroncos50thAnniversaryTeam,
        DetroitLions75thAnniversaryTeam,
        DetroitLionsAllTimeTeam,
        EightyGreatestRedskins,
        FiftyAnniversaryAllTimeTeam,
        FirstTeamAllAFL,
        FirstTeamAllAmerican,
        FirstTeamAllBigEight,
        FirstTeamAllBigTen,
        FirstTeamAllPac10,
        FirstTeamAllPro,
        FirstTeamLittleAllAmerican,
        NewEnglandPatriotsAll1980sTeam,
        NewEnglandPatriotsAll2000sTeam,
        NewEnglandPatriotsAll2010sTeam,
        NewEnglandPatriotsAllDynastyTeam,
        NewEnglandPatriots35thAnniversaryTeam,
        NewEnglandPatriots50thAnniversaryTeam,
        NineteenEightiesAllDecadeTeam,
        NineteenFiftiesAllDecadeTeam,
        NineteenFortiesAllDecadeTeam,
        NineteenNinetiesAllDecadeTeam,
        NineteenSeventiesAllDecadeTeam,
        NineteenSixtiesAllDecadeTeam,
        NineteenThirtiesAllDecadeTeam,
        OneHundredAnniversaryAllTimeTeam,
        OneHundredGreatestBearsOfAllTime,
        PFWAAllRookieTeam,
        PhiladelphiaEagles75thAnniversaryTeam,
        PittsburghSteelersAllTimeTeam,
        PrideOfTheJaguars,
        PrideOfTheLions,
        SecondTeamAllAFL,
        SecondTeamAllAmerican,
        SecondTeamAllBigTen,
        SecondTeamAllPro,
        SeventyFifthAnniversaryAllTimeTeam,
        TwoThousandsAllDecadeTeam,
        TwoThousandTensAllDecadeTeam,
        WashingtonCommandersNinetyGreatest
    };

    public static readonly AccomplishmentType[] YearAccomplishment =
    {
        AllAmerican,
        AllMLBFirstTeam,
        AllMLBSecondTeam,
        AllPro,
        AllRookieTeam,
        AllWorldBaseballClassicTeam,
        AmericanLeagueTripleCrown,
        ConsensusAllAmerican,
        FirstTeamAllAFL,
        FirstTeamAllBigEight,
        FirstTeamAllBigTen,
        FirstTeamAllAmerican,
        FirstTeamAllPac10,
        FirstTeamAllPro,
        FirstTeamLittleAllAmerican,
        FortyFortyClub,
        MajorLeagueBaseballAllCenturyTeam,
        MajorLeagueBaseballAllTimeTeam,
        NationalLeagueTripleCrown,
        PFWAAllRookieTeam,
        SecondTeamAllAFL,
        SecondTeamAllAmerican,
        SecondTeamAllBigTen,
        SecondTeamAllPro,
        ThirtyThirtyClub,
        ToppsAllStarRookieTeam
    };

    private AccomplishmentType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static AccomplishmentType Find(int id)
    {
        return All.SingleOrDefault(accomplishmentType => accomplishmentType.Id == id);
    }

    public static AccomplishmentType[] GetAll(params Sport[] sports)
    {
        if (!sports.Any())
            return All;

        var accomplishmentTypes = new List<AccomplishmentType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            accomplishmentTypes.AddRange(Baseball);

        if (sports.Any(sport => sport == Sport.Football))
            accomplishmentTypes.AddRange(Football);

        return accomplishmentTypes.OrderBy(accomplishmentType => accomplishmentType.Name).ToArray();
    }

    public static AccomplishmentType[] GetAll(SportLeagueLevel sportLeagueLevel)
    {
        if (sportLeagueLevel == SportLeagueLevel.MajorLeagueBaseball)
            return Baseball;

        return All;
    }

    public static bool IsDateAccomplishment(int id)
    {
        return DateAccomplishment.Any(accomplishmentType => accomplishmentType.Id == id);
    }

    public static bool IsYearAccomplishment(int id)
    {
        return YearAccomplishment.Any(accomplishmentType => accomplishmentType.Id == id);
    }
}
