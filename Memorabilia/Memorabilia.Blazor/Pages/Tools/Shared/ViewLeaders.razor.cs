namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewLeaders : ViewSportTools<LeaderModel>
{
    private LeadersModel _viewModel = new();

    private async Task OnInputChange(LeaderType leaderType)
    {
        _viewModel = await QueryRouter.Send(new GetLeaders(leaderType, Sport));
    }
}
