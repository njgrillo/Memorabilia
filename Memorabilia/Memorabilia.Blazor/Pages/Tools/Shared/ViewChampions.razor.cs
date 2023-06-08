namespace Memorabilia.Blazor.Pages.Tools.Shared;

public partial class ViewChampions 
    : ViewSportTools<ChampionModel>
{
    [Parameter]
    public ChampionType ChampionType { get; set; }

    protected ChampionsModel Model = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await QueryRouter.Send(new GetChampions(ChampionType.Id, Sport));
    }
}
