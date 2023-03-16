namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewAllStars : ViewSportTools<AllStarViewModel>
{
    private AllStarsViewModel _viewModel = new();

    private async Task OnInputChange(int year)
    {
        _viewModel = await QueryRouter.Send(new GetAllStars(year, Sport));
    }
}
