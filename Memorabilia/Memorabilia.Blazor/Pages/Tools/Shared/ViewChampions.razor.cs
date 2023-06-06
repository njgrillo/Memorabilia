namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewChampions : ViewSportTools<ChampionModel>
{
    [Parameter]
    public ChampionType ChampionType { get; set; }

    private ChampionsModel _viewModel = new();

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetChampions(ChampionType.Id, Sport));
    }
}
