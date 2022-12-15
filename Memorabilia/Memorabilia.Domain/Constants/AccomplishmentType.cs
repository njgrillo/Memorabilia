namespace Memorabilia.Domain.Constants;

public sealed class AccomplishmentType : DomainItemConstant
{    
    public static readonly AccomplishmentType AllMLBFirstTeam = new(5, "All-MLB First Team");
    public static readonly AccomplishmentType AllMLBSecondTeam = new(4, "All-MLB Second Team");
    public static readonly AccomplishmentType AllWorldBaseballClassicTeam = new(11, "All-World Baseball Classic Team");
    public static readonly AccomplishmentType AmericanLeagueTripleCrown = new(2, "American League Triple Crown", "AL Triple Crown");
    public static readonly AccomplishmentType CombinedNoHitter = new(8, "Combined No Hitter");
    public static readonly AccomplishmentType FortyFortyClub = new(18, "40-40 Club");
    public static readonly AccomplishmentType FourHomeRunsInAGame = new(12, "4 Home Runs in a Game");
    public static readonly AccomplishmentType HitForTheCycle = new(13, "Hit for the Cycle");
    public static readonly AccomplishmentType ImmaculateInning = new(14, "Immaculate Inning");
    public static readonly AccomplishmentType MajorLeagueBaseballAllCenturyTeam = new(6, "Major League Baseball All-Century Team");
    public static readonly AccomplishmentType MajorLeagueBaseballAllTimeTeam = new(7, "Major League Baseball All-Time Team");
    public static readonly AccomplishmentType NationalLeagueTripleCrown = new(10, "National League Triple Crown", "NL Triple Crown");
    public static readonly AccomplishmentType NoHitter = new(1, "No Hitter");
    public static readonly AccomplishmentType PerfectGame = new(9, "Perfect Game");
    public static readonly AccomplishmentType ThirtyThirtyClub = new(3, "30-30 Club");               
    public static readonly AccomplishmentType TwoGrandSlamsInOneInning = new(16, "2 Grand Slams in One Inning");               
    public static readonly AccomplishmentType UnassistedTriplePlay = new(17, "Unassisted Triple Play");
      
    public static readonly AccomplishmentType[] All =
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
        TwoGrandSlamsInOneInning,
        UnassistedTriplePlay
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
        TwoGrandSlamsInOneInning,
        UnassistedTriplePlay
    };

    public static readonly AccomplishmentType[] YearAccomplishment =
    {
        AllMLBFirstTeam,
        AllMLBSecondTeam,
        AllWorldBaseballClassicTeam,
        AmericanLeagueTripleCrown,
        FortyFortyClub,
        MajorLeagueBaseballAllCenturyTeam,
        MajorLeagueBaseballAllTimeTeam,
        NationalLeagueTripleCrown,
        ThirtyThirtyClub
    };

    private AccomplishmentType(int id, string name, string abbreviation = null) : base(id, name, abbreviation) { }

    public static AccomplishmentType Find(int id)
    {
        return All.SingleOrDefault(accomplishmentType => accomplishmentType.Id == id);
    }

    public static AccomplishmentType[] GetAll(params int[] sportIds)
    {
        if (!sportIds.Any())
            return All;

        var sports = sportIds.Select(id => Sport.Find(id));
        var accomplishmentTypes = new List<AccomplishmentType>();

        if (sports.Any(sport => sport == Sport.Baseball))
            accomplishmentTypes.AddRange(Baseball);            

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
