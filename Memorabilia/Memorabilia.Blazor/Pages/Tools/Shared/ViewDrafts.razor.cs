namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewDrafts : ViewSportTools<DraftViewModel>
{
    private DraftsViewModel _viewModel = new();

    private async Task OnInputChange(Franchise franchise)
    {
        _viewModel = await QueryRouter.Send(new GetDrafts(franchise, Sport));
    }
}
