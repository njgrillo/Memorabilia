namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewPlayers : ViewSportTools<PlayerViewModel>
{
    private PlayersViewModel _viewModel = new();  

    private async Task OnInputChange(int franchiseId)
    {
        _viewModel = await QueryRouter.Send(new GetPlayers(franchiseId, SportLeagueLevel));
    }
}
