namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class AllStarProfileModel
{
    private readonly Entity.AllStar _allStar;
    private readonly Entity.PersonTeam _team;

    public AllStarProfileModel(Entity.AllStar allStar, Entity.PersonTeam team)
    {
        _allStar = allStar;
        _team = team;
    }

    public string TeamName 
        => _team != null
        ? $"{_team.Team.Location} {_team.Team.Name}"
        : string.Empty;

    public int Year => _allStar.Year;
}
