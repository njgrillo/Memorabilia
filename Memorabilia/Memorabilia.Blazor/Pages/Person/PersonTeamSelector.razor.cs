namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonTeamSelector
{
    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public int[] SportIds { get; set; }
        = [];

    [Parameter]
    public List<PersonTeamEditModel> Teams { get; set; } 
        = [];

    protected PersonTeamEditModel Team
        = new();

    protected PersonTeamEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private string _search;

    private bool _teamIsReadOnly
        => EditMode == EditModeType.Update;

    private void Add()
    {
        if (Team.TeamId == 0)
            return;

        Model.TeamId = Team.TeamId;
        Model.FranchiseName = Team.FranchiseName;
        Model.TeamLocation = Team.TeamLocation;
        Model.TeamDisplayName = Team.TeamDisplayName;
        Model.TeamName = Team.TeamName;

        Teams.Add(Model);

        Team = new();
        Model = new();
    }

    private void Edit(PersonTeamEditModel team)
    {
        Team = team;
        Model = team;

        EditMode = EditModeType.Update;
    }

    private bool Filter(PersonTeamEditModel personTeam)
        => personTeam.Search(_search);

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

        EditMode = EditModeType.Add;
    }
}
