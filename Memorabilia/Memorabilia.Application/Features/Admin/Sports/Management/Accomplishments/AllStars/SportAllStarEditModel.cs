namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.AllStars;

public class SportAllStarEditModel : EditModel
{
    public SportAllStarEditModel() { }

    public SportAllStarEditModel(Entity.AllStar allStar)
    {
        Person = new PersonModel(allStar.Person);   
        Sport = Constant.Sport.Find(allStar.SportId);
        Year = allStar.Year;
    }

    public PersonModel Person { get; set; }
        = new();

    public string PersonName
        => Person.DisplayName;

    public Constant.Sport Sport { get; set; }

    public Constant.SportLeagueLevel SportLeagueLevel
    {
        get
        {
            if (Sport?.Id == Constant.Sport.Basketball.Id)
                return Constant.SportLeagueLevel.NationalBasketballAssociation;

            if (Sport?.Id == Constant.Sport.Football.Id)
                return Constant.SportLeagueLevel.NationalFootballLeague;

            return null;
        }
    }    

    public string SportName
        => Sport?.Name;

    public int? Year { get; set; }

    public bool Search(string search)
    {
        bool isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               (!isYear || Year == year) ||
               Person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.Nicknames.Any(x => x.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
