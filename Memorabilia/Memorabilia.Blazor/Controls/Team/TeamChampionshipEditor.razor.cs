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

    private void Remove(int teamId, int year)
    {
        var championship = Championships.SingleOrDefault(championship => championship.TeamId == teamId &&
                                                         championship.Year == year);

        if (championship == null)
            return;

        championship.IsDeleted = true;
    }
}
