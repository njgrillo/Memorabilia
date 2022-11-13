namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewRetiredNumbers : ViewSportTools<RetiredNumberViewModel>
{
    private RetiredNumbersViewModel _viewModel = new();

    private async Task OnInputChange(int franchiseId)
    {
        _viewModel = await QueryRouter.Send(new GetRetiredNumbers(franchiseId, SportLeagueLevel));
    }
}
