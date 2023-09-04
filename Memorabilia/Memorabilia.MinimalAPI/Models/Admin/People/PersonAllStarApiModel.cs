namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonAllStarApiModel
{
    private readonly Entity.AllStar _allStar;

    public PersonAllStarApiModel(Entity.AllStar allStar)
    {
        _allStar = allStar;
    }

    public string Sport
        => Constant.Sport.Find(_allStar.SportId).Name;

    public string SportLeageLevel
        => _allStar.SportLeagueLevelId.HasValue
        ? Constant.SportLeagueLevel.Find(_allStar.SportLeagueLevelId.Value).Name
        : null;

    public int Year
        => _allStar.Year;
}
