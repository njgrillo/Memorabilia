#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.GameStyleTypes;

public partial class ViewGameStyleTypes : ViewDomainItem<GameStyleTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveGameStyleType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetGameStyleTypes.Query()).ConfigureAwait(false);
    }
}
