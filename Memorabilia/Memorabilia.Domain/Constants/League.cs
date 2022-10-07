namespace Memorabilia.Domain.Constants;

public sealed class League : DomainItemConstant
{
    public static readonly League AmericanLeague = new(1, "American League", "AL");
    public static readonly League NationalLeague = new(2, "National League", "NL");
    public static readonly League NationalFootballLeague = new(3, "National Football League", "NFL");
    public static readonly League AmericanFootballLeague = new(4, "American Football League", "AFL");
    public static readonly League WesternLeague = new(5, "Western League", string.Empty);
    public static readonly League AmericanAssociation = new(6, "American Association", string.Empty);

    public static readonly League[] All =
    {
        AmericanLeague,
        AmericanFootballLeague,
        NationalFootballLeague,
        NationalLeague,
        WesternLeague,
        AmericanAssociation
    };

    public static readonly League[] MLB =
    {
        AmericanLeague,
        NationalLeague,
        AmericanAssociation,
        WesternLeague,
    };

    public static readonly League[] NFL =
    {
        NationalFootballLeague,
        AmericanFootballLeague
    };

    private League(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static League Find(int id)
    {
        return All.SingleOrDefault(league => league.Id == id);
    }

    public static League[] GetAll(SportLeagueLevel sportLeagueLevel)
    {
        if (sportLeagueLevel == SportLeagueLevel.MajorLeagueBaseball)
            return MLB;

        if (sportLeagueLevel == SportLeagueLevel.NationalFootballLeague)
            return NFL;

        return All;
    }
}
