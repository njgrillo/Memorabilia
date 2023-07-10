namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonTeamApiModel
{
    private readonly Entity.PersonTeam _personTeam;

    public PersonTeamApiModel(Entity.PersonTeam personTeam)
    {
        _personTeam = personTeam;
    }

    public int? BeginYear
        => _personTeam.BeginYear;

    public string DisplayName
        => _personTeam.Team.DisplayName;

    public int? EndYear
        => _personTeam.EndYear;

    public string Location
        => _personTeam.Team.Location;

    public string Name
        => _personTeam.Team.Name;

    public string Role
        => Constant.TeamRoleType.Find(_personTeam.TeamRoleTypeId).Name;
}
