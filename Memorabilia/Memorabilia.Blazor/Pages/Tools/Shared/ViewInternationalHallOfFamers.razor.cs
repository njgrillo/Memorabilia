namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewInternationalHallOfFamers : ViewSportTools<InternationalHallOfFameViewModel>
{
    private InternationalHallOfFamesViewModel _viewModel = new();

    private async Task OnInputChange(int internationalHallOfFameTypeId)
    {
        _viewModel = await QueryRouter.Send(new GetInternationalHallOfFames(internationalHallOfFameTypeId, SportLeagueLevel));
    }
}
