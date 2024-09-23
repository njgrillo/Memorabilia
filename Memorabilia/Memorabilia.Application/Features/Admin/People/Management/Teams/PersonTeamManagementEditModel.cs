namespace Memorabilia.Application.Features.Admin.People.Management.Teams;

public class PersonTeamManagementEditModel : EditModel
{
    public PersonTeamManagementEditModel()
    {
        TemporaryId = Guid.NewGuid();
    }

    public PersonTeamManagementEditModel(Entity.PersonTeam personTeam)
    {
        BeginYear = personTeam.BeginYear;
        EndYear = personTeam.EndYear;
        Id = personTeam.Id;
        PersonId = personTeam.PersonId;    
        Team = new PersonTeamEditModel(new PersonTeamModel(personTeam));
        TeamRoleType = Constant.TeamRoleType.Find(personTeam.TeamRoleTypeId);
    }

    public int? BeginYear { get; set; }

    public int? EndYear { get; set; }

    public int PersonId { get; set; }

    public PersonTeamEditModel Team { get; set; }
        = new();

    public Constant.TeamRoleType TeamRoleType { get; set; }
        = Constant.TeamRoleType.Player;

    public Guid? TemporaryId { get; set; }

    public bool Search(string search)
    {
        bool isYear = search.TryParse(out int year);

        return search.IsNullOrEmpty() ||
               Team.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Team.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Team.TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Team.TeamLocation.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Team.TeamRoleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && BeginYear == year) ||
               (isYear && EndYear == year);
    }

    public void Set(int id, PersonTeamEditModel team, int? beginYear, int? endYear, int teamRoleTypeId)
    {
        BeginYear = beginYear; 
        EndYear = endYear; 
        Id = id;
        Team = team;
        TeamRoleType = Constant.TeamRoleType.Find(teamRoleTypeId);
    }
}
