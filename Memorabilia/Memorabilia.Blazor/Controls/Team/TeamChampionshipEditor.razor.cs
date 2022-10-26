#nullable disable

namespace Memorabilia.Blazor.Controls.Team;

public partial class TeamChampionshipEditor : ComponentBase
{
    [Parameter]
    public List<SaveTeamChampionshipViewModel> Championships { get; set; } = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private SaveTeamChampionshipViewModel _viewModel = new();

    private void Add()
    {
        Championships.Add(_viewModel);

        _viewModel = new SaveTeamChampionshipViewModel();
    }
}
