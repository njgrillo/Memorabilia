#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class ViewChampionTypes : IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private ChampionTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveChampionType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetChampionTypes.Query()).ConfigureAwait(false);
    }
}
