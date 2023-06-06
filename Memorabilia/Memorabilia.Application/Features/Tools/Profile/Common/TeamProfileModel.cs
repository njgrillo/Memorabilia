namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class TeamProfileModel
{
    private readonly Entity.PersonTeam _team;

    public TeamProfileModel(Entity.PersonTeam team)
    {
        _team = team;
    }

    public string BeginYear 
        => _team.BeginYear?.ToString() ?? string.Empty;

    public string EndYear 
        => _team.EndYear?.ToString() ?? string.Empty;

    public string Name 
        => $"{_team.Team.Location} {_team.Team.Name}";
}
