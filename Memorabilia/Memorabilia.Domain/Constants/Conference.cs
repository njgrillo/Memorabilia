namespace Memorabilia.Domain.Constants;

public sealed class Conference : DomainItemConstant
{
    public static readonly Conference AmericanFootballConference = new(1, "AFC - American Football Conference", "AFC");
    public static readonly Conference NationalFootballConference = new(2, "NFC - National Football Conference", "NFC");
    public static readonly Conference EasternConference = new(3, "Eastern Conference", "EAST");
    public static readonly Conference WesternConference = new(4, "Western Conference", "WEST");
    public static readonly Conference AmericanConference = new(5, "American Conference", string.Empty);
    public static readonly Conference NFLEasternConference = new(6, "Eastern Conference", string.Empty);
    public static readonly Conference NFLWesternConference = new(7, "Western Conference", string.Empty);
    public static readonly Conference NFLNationalConference = new(8, "National Conference", string.Empty);
    public static readonly Conference AllAmericanFootballConference = new(9, "All-America Football Conference", string.Empty);

    public static readonly Conference[] All =
    {
        AmericanConference,
        AmericanFootballConference,
        NationalFootballConference,
        NFLEasternConference,
        NFLNationalConference,
        NFLWesternConference,
        EasternConference,
        WesternConference,
        AllAmericanFootballConference
    };

    public static readonly Conference[] NationalBasketballAssociation =
    {
        EasternConference,
        WesternConference
    };

    public static readonly Conference[] NationalFootballLeague =
    {
        AmericanFootballConference,
        NationalFootballConference,
        AllAmericanFootballConference,
        AmericanConference,
        NFLEasternConference,
        NFLNationalConference,
        NFLWesternConference
    };

    private Conference(int id, string name, string abbreviation) : base(id, name, abbreviation) { }

    public static Conference Find(int id)
    {
        return All.SingleOrDefault(conference => conference.Id == id);
    }

    public static Conference[] GetAll(SportLeagueLevel sportLeagueLevel)
    {
        if (sportLeagueLevel == SportLeagueLevel.NationalBasketballAssociation)
            return NationalBasketballAssociation;

        if (sportLeagueLevel == SportLeagueLevel.NationalFootballLeague)
            return NationalFootballLeague;

        return All;
    }
}
