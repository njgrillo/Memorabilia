namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewLeaders : ViewSportTools<LeaderViewModel>
{
    private LeadersViewModel _viewModel = new();

    private async Task OnInputChange(LeaderType leaderType)
    {
        _viewModel = await QueryRouter.Send(new GetLeaders(leaderType, SportLeagueLevel));
    }
}
