using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.Players;

public class PlayerViewModel
{
    private readonly PersonTeam _personTeam;

    public PlayerViewModel(PersonTeam personTeam)
    {
        _personTeam = personTeam;
    }

    public string BeginYear => _personTeam.BeginYear.HasValue ? _personTeam.BeginYear.ToString() : string.Empty;

    public string EndYear => _personTeam.EndYear.HasValue ? _personTeam.EndYear.ToString() : string.Empty;

    public int PersonId => _personTeam.PersonId;

    public string PersonImageFileName => _personTeam.Person.ImageFileName;

    public string PersonName => _personTeam.Person.DisplayName;

    public string ProfileLink => $"/Tools/BaseballProfile/{PersonId}";

    public string TeamName => _personTeam.Team.Name;

    public int TeamRoleTypeId => _personTeam.TeamRoleTypeId;

    public string TeamRoleTypeName => Domain.Constants.TeamRoleType.Find(TeamRoleTypeId)?.Name;
}
