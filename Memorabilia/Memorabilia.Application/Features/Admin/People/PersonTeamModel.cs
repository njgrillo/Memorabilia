namespace Memorabilia.Application.Features.Admin.People;

public class PersonTeamModel
{
    private readonly Entity.PersonTeam _personTeam;

    public PersonTeamModel() { }

    public PersonTeamModel(Entity.PersonTeam personTeam)
    {
        _personTeam = personTeam;
    }

    public int? BeginYear 
        => _personTeam.BeginYear;

    public int? EndYear 
        => _personTeam.EndYear; 

    public string FranchiseName 
        => _personTeam.Team.Franchise.Name;

    public int Id 
        => _personTeam.Id;        

    public int PersonId 
        => _personTeam.PersonId;

    public int SportId 
        => _personTeam.Team.Franchise.SportLeagueLevel.SportId;

    public int SportLeagueLevelId 
        => _personTeam.Team.Franchise.SportLeagueLevelId;

    public int TeamId 
        => _personTeam.TeamId;

    public string TeamLocation 
        => _personTeam.Team.Location;

    public string TeamName 
        => _personTeam.Team?.Name;

    public int TeamRoleTypeId 
        => _personTeam.TeamRoleTypeId;
}
