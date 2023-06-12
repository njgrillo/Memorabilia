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
}
