namespace Memorabilia.Blazor.Pages.Team;

public partial class TeamLeagueEditor
{
    [Parameter]
    public List<TeamLeagueEditModel> Leagues { get; set; } 
        = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected TeamLeagueEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private void Add()
    {
        Leagues.Add(Model);

        Model = new();
    }

    private void Edit(TeamLeagueEditModel league)
    {
        Model.LeagueId = league.LeagueId;
        Model.BeginYear = league.BeginYear;
        Model.EndYear = league.EndYear;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        TeamLeagueEditModel league 
            = Leagues.Single(league => league.LeagueId == Model.LeagueId);

        league.LeagueId = Model.LeagueId;
        league.BeginYear = Model.BeginYear;
        league.EndYear = Model.EndYear;

        Model = new();

        EditMode = EditModeType.Add;
    }
}
