namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewPlayers 
    : ViewSportTools<PlayerModel>
{
    protected PlayersModel Model = new();  

    private async Task OnInputChange(Franchise franchise)
    {
        Model = await QueryRouter.Send(new GetPlayers(franchise, Sport));
    }
}
