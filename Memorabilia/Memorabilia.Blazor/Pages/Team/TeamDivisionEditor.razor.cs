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

    private bool _canAdd 
        = true;

    private bool _canEditDivision 
        = true;

    private bool _canUpdate;    

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

        _canAdd = false;
        _canEditDivision = false;
        _canUpdate = true;
    }

    private void Update()
    {
        TeamDivisionEditModel division 
            = Divisions.Single(division => division.Division.Id == Model.Division.Id);

        division.Division = Model.Division;
        division.BeginYear = Model.BeginYear;
        division.EndYear = Model.EndYear;

        Model = new ();

        _canAdd = false;
        _canEditDivision = false;
        _canUpdate = true;
    }
}
