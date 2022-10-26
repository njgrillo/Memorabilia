#nullable disable

namespace Memorabilia.Blazor.Controls.Team;

public partial class TeamConferenceEditor : ComponentBase
{
    [Parameter]
    public List<SaveTeamConferenceViewModel> Conferences { get; set; } = new();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private SaveTeamConferenceViewModel _viewModel = new();

    private void Add()
    {
        Conferences.Add(_viewModel);

        _viewModel = new SaveTeamConferenceViewModel();
    }
}
