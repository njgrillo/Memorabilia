#nullable disable

namespace Memorabilia.Blazor.Controls.Team;

public partial class TeamDivisionEditor : ComponentBase
{
    [Parameter]
    public List<SaveTeamDivisionViewModel> Divisions { get; set; } = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private SaveTeamDivisionViewModel _viewModel = new();

    private void Add()
    {
        Divisions.Add(_viewModel);

        _viewModel = new SaveTeamDivisionViewModel();
    }
}
