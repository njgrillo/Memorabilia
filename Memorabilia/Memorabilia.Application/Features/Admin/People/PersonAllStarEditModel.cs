namespace Memorabilia.Application.Features.Admin.People;

public class PersonAllStarEditModel : EditModel
{
    public PersonAllStarEditModel() { }

    public PersonAllStarEditModel(Entity.AllStar allStar)
    {
        Id = allStar.Id;
        PersonId = allStar.PersonId;
        Sport = Constant.Sport.Find(allStar.SportId);
        SportLeagueLevelId = allStar.SportLeagueLevelId ?? 0;
        Year = allStar.Year;
    }

    public int PersonId { get; set; }

    public Constant.Sport Sport { get; set; }

    public int SportLeagueLevelId { get; set; }

    public string SportLeagueLevelName 
        => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;

    public string SportName 
        => Sport?.Name;

    public int Year { get; set; }

    public bool Search(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
           SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (isNumeric && Year == year);
    }

    public void SetSport(Constant.Sport[] sports)
    {
        if (sports.Length != 1)
            return;
            
        Sport = sports.FirstOrDefault();
    }

    public void SetSportLeagueLevelId(Constant.Sport[] sports)
    {
        if (sports.Any(sport => sport == Constant.Sport.Basketball))
            SportLeagueLevelId = Constant.SportLeagueLevel.NationalBasketballAssociation.Id;

        if (sports.Any(sport => sport == Constant.Sport.Football))
            SportLeagueLevelId = Constant.SportLeagueLevel.NationalFootballLeague.Id;
    }
}
