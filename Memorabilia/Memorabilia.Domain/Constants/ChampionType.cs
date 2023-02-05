namespace Memorabilia.Domain.Constants;

public sealed class ChampionType : DomainItemConstant
{   
    public static readonly ChampionType NBAFinals = new(4, "NBA Finals");
    public static readonly ChampionType StanleyCup = new(3, "Stanley Cup");
    public static readonly ChampionType SuperBowl = new(2, "Super Bowl", "SB");
    public static readonly ChampionType WorldSeries = new(1, "World Series", "WS");

    public static readonly ChampionType[] All =
    {
        NBAFinals,
        StanleyCup,
        SuperBowl,
        WorldSeries
    };

    private ChampionType(int id, string name, string abbreviation = null) 
        : base(id, name, abbreviation) { }

    public static ChampionType Find(int id)
        => All.SingleOrDefault(championType => championType.Id == id);

    public static ChampionType Find(SportLeagueLevel sportLeagueLevel)
    {
        if (sportLeagueLevel == SportLeagueLevel.MajorLeagueBaseball)
            return WorldSeries;

        if (sportLeagueLevel == SportLeagueLevel.NationalBasketballAssociation)
            return NBAFinals;

        if (sportLeagueLevel == SportLeagueLevel.NationalFootballLeague)
            return SuperBowl;

        if (sportLeagueLevel == SportLeagueLevel.NationalHockeyLeague)
            return StanleyCup;

        return null;
    }
}
