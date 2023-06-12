namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonTeamSelector
{
    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public int[] SportIds { get; set; }
        = Array.Empty<int>();

    [Parameter]
    public List<PersonTeamEditModel> Teams { get; set; } 
        = new();

    protected PersonTeamEditModel Team
        = new();

    protected PersonTeamEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditTeam 
        = true;

    private bool _canUpdate;    

    private void Add()
    {
        if (Team.TeamId == 0)
            return;

        Model.TeamId = Team.TeamId;
        Model.FranchiseName = Team.FranchiseName;
        Model.TeamLocation = Team.TeamLocation;
        Model.TeamName = Team.TeamName;

        Teams.Add(Model);

        Team = new();
        Model = new();
    }

    private void Edit(PersonTeamEditModel team)
    {
        Team = team;
        Model = team;

        _canAdd = false;
        _canEditTeam = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonTeamEditModel team = Model.Id > 0
            ? Teams.Single(team => team.Id == Model.Id)
            : Teams.Single(team => team.TeamId == Model.TeamId && 
                           team.TeamRoleType.Id == Model.TeamRoleType.Id);

        team.BeginYear = Model.BeginYear;
        team.EndYear = Model.EndYear;
        team.TeamRoleType = Model.TeamRoleType;

        Team = new();
        Model = new();

        _canAdd = true;
        _canEditTeam = true;
        _canUpdate = false;
    }
}
