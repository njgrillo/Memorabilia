namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewPlayers : ViewSportTools<PlayerViewModel>
{
    private PlayersViewModel _viewModel = new();  

    private async Task OnInputChange(Franchise franchise)
    {
        _viewModel = await QueryRouter.Send(new GetPlayers(franchise, Sport));
    }
}
