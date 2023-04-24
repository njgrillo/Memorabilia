

namespace Memorabilia.Blazor.Controls.Team;

public partial class TeamLeagueEditor : ComponentBase
{
    [Parameter]
    public List<SaveTeamLeagueViewModel> Leagues { get; set; } = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private bool _canAdd = true;
    private bool _canEditLeague = true;
    private bool _canUpdate;
    private SaveTeamLeagueViewModel _viewModel = new();

    private void Add()
    {
        Leagues.Add(_viewModel);

        _viewModel = new();
    }

    private void Edit(SaveTeamLeagueViewModel league)
    {
        _viewModel.LeagueId = league.LeagueId;
        _viewModel.BeginYear = league.BeginYear;
        _viewModel.EndYear = league.EndYear;

        _canAdd = false;
        _canEditLeague = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var league = Leagues.Single(league => league.LeagueId == _viewModel.LeagueId);

        league.LeagueId = _viewModel.LeagueId;
        league.BeginYear = _viewModel.BeginYear;
        league.EndYear = _viewModel.EndYear;

        _viewModel = new();

        _canAdd = false;
        _canEditLeague = false;
        _canUpdate = true;
    }
}
