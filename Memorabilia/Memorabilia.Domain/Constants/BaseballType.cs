﻿namespace Memorabilia.Domain.Constants;

public sealed class BaseballType : DomainItemConstant
{
    public static readonly BaseballType AllStar = new(2, "All Star");
    public static readonly BaseballType AllStarFuturesGame = new(19, "All Star Future's Game");
    public static readonly BaseballType AmericanLeague = new(7, "American League");
    public static readonly BaseballType Black = new(1, "Black Baseball", "ROMLBBG");
    public static readonly BaseballType Commemorative = new(12, "Commemorative");
    public static readonly BaseballType CyYoung = new(11, "Cy Young");
    public static readonly BaseballType FathersDay = new(9, "Father's Day");
    public static readonly BaseballType Gold = new(14, "Gold", "ROMLBG");
    public static readonly BaseballType GoldGlove = new(15, "Gold Glove", "RGGBB");
    public static readonly BaseballType GoldWorldSeries = new(17, "Gold World Series");
    public static readonly BaseballType HallOfFame = new(22, "Hall of Fame");
    public static readonly BaseballType HomeRunDerby = new(13, "Home Run Derby");
    public static readonly BaseballType MemorialDay = new(23, "Memorial Day");
    public static readonly BaseballType MothersDay = new(10, "Mother's Day", "ROMLBMOM");
    public static readonly BaseballType NationalLeague = new(8, "National League");
    public static readonly BaseballType None = new(6, "None");
    public static readonly BaseballType Official = new(4, "Official Major League Baseball", "ROMLB");
    public static readonly BaseballType OpeningDay = new(20, "Opening Day");
    public static readonly BaseballType Other = new(5, "Other");
    public static readonly BaseballType PostSeason = new(21, "Post Season");
    public static readonly BaseballType SpringTraining = new(16, "Spring Training");
    public static readonly BaseballType TeamAnniversary = new(18, "Team Anniversary");
    public static readonly BaseballType WorldSeries = new(3, "World Series");

    public static readonly BaseballType[] All =
    {
        AllStar,
        AllStarFuturesGame,
        AmericanLeague,
        Black,
        Commemorative,
        CyYoung,
        FathersDay,
        Gold,
        GoldGlove,
        GoldWorldSeries,
        HallOfFame,
        HomeRunDerby,
        MothersDay,
        NationalLeague,
        None,
        Official,
        OpeningDay,
        Other,
        PostSeason,
        SpringTraining,
        TeamAnniversary,
        WorldSeries
    };

    public static readonly BaseballType[] Commissioner =
    {
        AllStar,
        AllStarFuturesGame,
        Black,
        Commemorative,
        CyYoung,
        FathersDay,
        Gold,
        GoldGlove,
        GoldWorldSeries,
        HallOfFame,
        HomeRunDerby,
        MothersDay,
        Official,
        OpeningDay,
        PostSeason,
        SpringTraining,
        TeamAnniversary,
        WorldSeries
    };

    public static readonly BaseballType[] GameWorthly =
    {
        AllStar,
        AllStarFuturesGame,
        AmericanLeague,
        Commemorative,
        FathersDay,
        HomeRunDerby,
        MothersDay,
        NationalLeague,
        Official,
        OpeningDay,
        PostSeason,
        SpringTraining,
        TeamAnniversary,
        WorldSeries
    };

    public static readonly BaseballType[] LeaguePresident =
    {
        AmericanLeague,
        NationalLeague
    };

    public static readonly BaseballType[] Yearly =
    {
        AllStar,
        AllStarFuturesGame,
        Commemorative,
        GoldWorldSeries,
        HomeRunDerby,
        OpeningDay,
        Other,
        PostSeason,
        SpringTraining,
        WorldSeries
    };

    private BaseballType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }        

    public static bool CanHaveAnniversary(BaseballType baseballType)
        => baseballType == TeamAnniversary;

    public static bool CanHaveYear(BaseballType baseballType)
        => Yearly.Contains(baseballType);

    public static BaseballType Find(int id)
        => All.SingleOrDefault(baseballType => baseballType.Id == id);

    public static BaseballType[] GetAll(GameStyleType gameStyleType)
    {
        if (gameStyleType == null || gameStyleType == GameStyleType.None)
            return All;

        return GameWorthly;
    }

    public static bool IsCommissionerType(BaseballType baseballType)
        => Commissioner.Contains(baseballType);

    public static bool IsGameWorthly(BaseballType baseballType)
        => GameWorthly.Contains(baseballType);

    public static bool IsLeaguePresidentType(BaseballType baseballType)
        => LeaguePresident.Contains(baseballType);
}
