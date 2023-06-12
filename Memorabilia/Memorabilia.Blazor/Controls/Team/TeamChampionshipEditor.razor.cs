

namespace Memorabilia.Blazor.Controls.Team;

public partial class TeamChampionshipEditor : ComponentBase
{
    [Parameter]
    public List<TeamChampionshipEditModel> Championships { get; set; } = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private TeamChampionshipEditModel _viewModel = new();
    private string _years;

    private void Add()
    {
        foreach (var year in _years.ToIntArray())
        {
            Championships.Add(new() { ChampionshipTypeId = _viewModel.ChampionshipTypeId, 
                                      TeamId = _viewModel.TeamId,
                                      Year = year });
        }

        _viewModel = new();
        _years = string.Empty;
    }
}
