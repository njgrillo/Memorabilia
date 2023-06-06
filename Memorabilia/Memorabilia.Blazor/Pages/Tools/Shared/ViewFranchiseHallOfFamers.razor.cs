using Memorabilia.Domain.Constants;

namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewFranchiseHallOfFamers : ViewSportTools<FranchiseHallOfFameModel>
{
    private FranchiseHallOfFamesModel _viewModel = new();

    private async Task OnInputChange(Franchise franchise)
    {
        _viewModel = await QueryRouter.Send(new GetFranchiseHallOfFames(franchise, Sport));
    }
}
