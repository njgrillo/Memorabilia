namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewRetiredNumbers : ViewSportTools<RetiredNumberModel>
{
    private RetiredNumbersModel _viewModel = new();

    private async Task OnInputChange(Franchise franchise)
    {
        _viewModel = await QueryRouter.Send(new GetRetiredNumbers(franchise, Sport));
    }
}
