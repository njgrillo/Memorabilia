namespace Memorabilia.Domain.Constants;

public sealed class Sport : DomainItemConstant
{
    public static readonly Sport AutoRacing = new(17, "Auto Racing");
    public static readonly Sport Baseball = new(1, "Baseball");
    public static readonly Sport Basketball = new(2, "Basketball");
    public static readonly Sport Boxing = new(11, "Boxing");
    public static readonly Sport Cycling = new(16, "Cycling");
    public static readonly Sport Diving = new(18, "Diving");
    public static readonly Sport FigureSkating = new (19, "Figure Skating");
    public static readonly Sport Football = new(3, "Football");
    public static readonly Sport Golf = new(6, "Golf");
    public static readonly Sport Gymnastics = new(20, "Gymnastics");
    public static readonly Sport Hockey = new(4, "Hockey");
    public static readonly Sport HorseRacing = new(15, "Horse Racing");
    public static readonly Sport MixedMartialArts = new(12, "Mixed Martial Arts");
    public static readonly Sport Skiing = new(22, "Skiing");
    public static readonly Sport Soccer= new(5, "Soccer", "Futbol");
    public static readonly Sport SpeedSkating = new (21, "Speed Skating");
    public static readonly Sport Swimming = new(14, "Swimming");
    public static readonly Sport Tennis= new(7, "Tennis");
    public static readonly Sport TrackAndField= new(13, "Track & Field");

    public static readonly Sport[] All =
    [
        AutoRacing,
        Baseball,
        Basketball,
        Boxing,
        Cycling,
        Diving,
        FigureSkating,
        Football,
        Golf,
        Gymnastics,
        Hockey,
        HorseRacing,
        MixedMartialArts,
        Skiing,
        Soccer,
        SpeedSkating,
        Swimming,
        Tennis,
        TrackAndField
    ];

    public static readonly Sport[] AllStarGameSports =
    [
        Baseball,
        Basketball,
        Hockey
    ];

    public static readonly Sport[] GloveSports =
    [
        Baseball,
        Boxing,
        Football,
        Golf,
        Hockey,
        MixedMartialArts,
        Soccer
    ];

    public static readonly Sport[] JerseySports =
    [
        Baseball,
        Basketball,
        Football,
        Hockey    
    ];

    public static readonly Sport[] PositionSports =
    [
        Baseball,
        Basketball,
        Football,
        Hockey,
        Soccer
    ];

    public static readonly Sport[] ProBowlGameSports =
    [
        Football
    ];

    public static readonly Sport[] ShoeSports =
    [
        Baseball,
        Basketball,
        Boxing,
        Cycling,
        Football,
        Golf,
        Soccer,
        TrackAndField
    ];

    public static readonly Sport[] TrunkSports =
    [
        Boxing,
        MixedMartialArts,
        Swimming
    ];

    public static readonly Sport[] WristBandSports =
    [
        Baseball,
        Basketball,
        Football,
        Soccer,
        Tennis
    ];

    private Sport(int id, string name, string alternateName = null) 
        : base(id, name)
    {
        AlternateName = alternateName;
    }

    public string AlternateName { get; }

    public static Sport Find(int id)
        => All.SingleOrDefault(sport => sport.Id == id);

    public static Sport Find(string name)
        => All.SingleOrDefault(sport => sport.Name == name);

    public static Sport[] GetAll(ItemType itemType)
    {
        if (itemType == ItemType.Glove)
            return GloveSports;

        if (itemType == ItemType.Jersey || itemType == ItemType.JerseyNumber)
            return JerseySports;

        if (itemType == ItemType.Shoe)
            return ShoeSports;

        if (itemType == ItemType.Trunks)
            return TrunkSports;

        if (itemType == ItemType.WristBand)
            return WristBandSports;

        return All;
    }

    public static bool HasAllStarGames(params Sport[] sports)
        => sports.Any(sport => AllStarGameSports.Contains(sport));

    public static bool HasProBowlGames(params Sport[] sports)
        => sports.Any(sport => ProBowlGameSports.Contains(sport));

    public static bool IsPositionSport(params Sport[] sports)
        => sports.Any(sport => PositionSports.Contains(sport));
}
