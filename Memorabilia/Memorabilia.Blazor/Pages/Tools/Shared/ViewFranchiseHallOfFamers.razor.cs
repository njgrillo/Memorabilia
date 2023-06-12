namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewFranchiseHallOfFamers : ViewSportTools<FranchiseHallOfFameModel>
{
    private FranchiseHallOfFamesModel Model = new();

    private async Task OnInputChange(Franchise franchise)
    {
        Model = new(await QueryRouter.Send(new GetFranchiseHallOfFames(franchise, Sport)), Sport)
                {
                    Franchise = franchise
                };
    }
}
