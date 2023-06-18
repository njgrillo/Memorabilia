namespace Memorabilia.Blazor.Pages.Team;

public partial class TeamDivisionEditor
{
    [Parameter]
    public List<TeamDivisionEditModel> Divisions { get; set; } 
        = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private TeamDivisionEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        Divisions.Add(Model);

        Model = new ();
    }

    private void Edit(TeamDivisionEditModel division)
    {
        Model.Division = division.Division;
        Model.BeginYear = division.BeginYear;
        Model.EndYear = division.EndYear;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        TeamDivisionEditModel division 
            = Divisions.Single(division => division.Division.Id == Model.Division.Id);

        division.Division = Model.Division;
        division.BeginYear = Model.BeginYear;
        division.EndYear = Model.EndYear;

        Model = new ();

        EditMode = EditModeType.Add;
    }
}
