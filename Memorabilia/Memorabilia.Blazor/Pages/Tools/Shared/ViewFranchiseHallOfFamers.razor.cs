namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewFranchiseHallOfFamers : ViewSportTools<FranchiseHallOfFameViewModel>
{
    private FranchiseHallOfFamesViewModel _viewModel = new();

    private async Task OnInputChange(int franchiseId)
    {
        _viewModel = await QueryRouter.Send(new GetFranchiseHallOfFames(franchiseId, SportLeagueLevel));
    }
}
