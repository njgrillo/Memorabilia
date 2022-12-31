namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAwards : ViewSportTools<AwardViewModel>
{
    private AwardsViewModel _viewModel = new();

    private async Task OnInputChange(AwardType awardType)
    {
        _viewModel = await QueryRouter.Send(new GetAwards(awardType, Sport));
    }
}
