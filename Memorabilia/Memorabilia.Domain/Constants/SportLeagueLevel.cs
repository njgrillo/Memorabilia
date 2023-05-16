namespace Memorabilia.Domain.Constants;

public sealed class SportLeagueLevel : DomainItemConstant
{
    public static readonly SportLeagueLevel AmericanBasketballAssociation = new(8, "American Basketball Association", "ABA", Sport.Basketball);
    public static readonly SportLeagueLevel AmericanFootballLeague = new(9, "American Football League", "AFL", Sport.Football);
    public static readonly SportLeagueLevel MajorLeagueBaseball = new(1, "Major League Baseball", "MLB", Sport.Baseball);
    public static readonly SportLeagueLevel NationalFootballLeague = new(2, "National Football League", "NFL", Sport.Football);
    public static readonly SportLeagueLevel NationalBasketballAssociation = new(3, "National Basketball Association", "NBA", Sport.Basketball);
    public static readonly SportLeagueLevel NationalHockeyLeague = new(4, "National Hockey League", "NHL", Sport.Hockey);

    public static readonly SportLeagueLevel[] All =
    {
        AmericanBasketballAssociation,
        AmericanFootballLeague,
        MajorLeagueBaseball,
        NationalBasketballAssociation,
        NationalFootballLeague,        
        NationalHockeyLeague
    };

    public static readonly SportLeagueLevel[] Conference =
    {
        NationalBasketballAssociation,
        NationalFootballLeague,        
        NationalHockeyLeague
    };

    private SportLeagueLevel(int id, string name, string abbreviation, Sport sport) 
        : base(id, name, abbreviation) 
    { 
        Sport = sport;
    }

    public Sport Sport { get; private set; }

    public static SportLeagueLevel Find(int id)
        => All.SingleOrDefault(sportLeagueLevel => sportLeagueLevel.Id == id);

    public static SportLeagueLevel Find(string name)
        => All.SingleOrDefault(sportLeagueLevel => sportLeagueLevel.Name == name);

    public static SportLeagueLevel[] GetAll(params int[] sportIds)
    {
        var sportLeagueLevels = new List<SportLeagueLevel>();

        if (sportIds.Contains(Sport.Baseball.Id))
            sportLeagueLevels.Add(MajorLeagueBaseball);

        if (sportIds.Contains(Sport.Basketball.Id))
        {
            sportLeagueLevels.Add(AmericanBasketballAssociation);
            sportLeagueLevels.Add(NationalBasketballAssociation);
        }            

        if (sportIds.Contains(Sport.Football.Id))
        {
            sportLeagueLevels.Add(AmericanFootballLeague);
            sportLeagueLevels.Add(NationalFootballLeague);
        }            

        if (sportIds.Contains(Sport.Hockey.Id))
            sportLeagueLevels.Add(NationalHockeyLeague);

        return sportLeagueLevels.OrderBy(sportLeagueLevel => sportLeagueLevel.Name).ToArray();
    }
}
