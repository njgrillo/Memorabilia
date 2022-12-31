using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.Players;

public class PlayerViewModel : PersonSportToolViewModel
{
    private readonly PersonTeam _personTeam;

    public PlayerViewModel(PersonTeam personTeam, Domain.Constants.Sport sport)
    {
        _personTeam = personTeam;
        Sport = sport;
    }

    public string BeginYear => _personTeam.BeginYear.HasValue ? _personTeam.BeginYear.ToString() : string.Empty;

    public string EndYear => _personTeam.EndYear.HasValue ? _personTeam.EndYear.ToString() : string.Empty;

    public override int PersonId => _personTeam.PersonId;

    public override string PersonImageFileName => _personTeam.Person.ImageFileName;

    public override string PersonName => _personTeam.Person.DisplayName;

    public string TeamName => _personTeam.Team.Name;

    public int TeamRoleTypeId => _personTeam.TeamRoleTypeId;

    public string TeamRoleTypeName => Domain.Constants.TeamRoleType.Find(TeamRoleTypeId)?.Name;
}
