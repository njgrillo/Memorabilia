namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewChampions : ViewSportTools<ChampionViewModel>
{
    private ChampionsViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetChampions(ChampionType.WorldSeries.Id, SportLeagueLevel));
    }
}
