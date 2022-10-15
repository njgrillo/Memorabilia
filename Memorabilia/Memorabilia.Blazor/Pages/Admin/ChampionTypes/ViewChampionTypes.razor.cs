#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ChampionTypes;

public partial class ViewChampionTypes : ViewDomainItem<ChampionTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveChampionType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetChampionTypes.Query());
    }
}
