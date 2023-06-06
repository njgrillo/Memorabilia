namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public class AllStarModel : PersonSportToolModel
{
    private readonly Entity.AllStar _allstar;

    public AllStarModel(Entity.AllStar allstar, Constant.Sport sport)
    {
        _allstar = allstar;
        Sport = sport;
    }

    public int NumberOfGames { get; set; } = 1;

    public override int PersonId 
        => _allstar.PersonId;

    public override string PersonImageFileName 
        => _allstar.Person.ImageFileName;

    public override string PersonName 
        => _allstar.Person.DisplayName;

    public Constant.SportLeagueLevel SportLeagueLevel
        => _allstar.SportLeagueLevelId.HasValue
               ? Constant.SportLeagueLevel.Find(_allstar.SportLeagueLevelId.Value)
               : null; 

    public string Year 
        => _allstar.Year.ToString();
}
