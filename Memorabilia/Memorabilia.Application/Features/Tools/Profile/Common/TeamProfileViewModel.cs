using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class TeamProfileViewModel
{
    private readonly PersonTeam _team;

    public TeamProfileViewModel(PersonTeam team)
    {
        _team = team;
    }

    public string BeginYear => _team.BeginYear?.ToString() ?? string.Empty;

    public string EndYear => _team.EndYear?.ToString() ?? string.Empty;

    public string Name => $"{_team.Team.Location} {_team.Team.Name}";
}
