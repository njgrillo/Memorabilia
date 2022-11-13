#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewDrafts : ViewSportTools<DraftViewModel>
{
    private DraftsViewModel _viewModel = new();

    private async Task OnInputChange(int franchiseId)
    {
        _viewModel = await QueryRouter.Send(new GetDrafts(franchiseId, SportLeagueLevel));
    }
}
