namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewPlayers : ViewSportTools<PlayerModel>
{
    private PlayersModel _viewModel = new();  

    private async Task OnInputChange(Franchise franchise)
    {
        _viewModel = await QueryRouter.Send(new GetPlayers(franchise, Sport));
    }
}
