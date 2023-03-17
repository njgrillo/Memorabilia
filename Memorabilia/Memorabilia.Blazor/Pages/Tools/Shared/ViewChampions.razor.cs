namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewChampions : ViewSportTools<ChampionViewModel>
{
    [Parameter]
    public ChampionType ChampionType { get; set; }

    private ChampionsViewModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetChampions(ChampionType.Id, Sport));
    }
}
