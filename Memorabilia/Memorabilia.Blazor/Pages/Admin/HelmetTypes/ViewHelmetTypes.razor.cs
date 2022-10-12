#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class ViewHelmetTypes : ViewDomainItem<HelmetTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveHelmetType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetHelmetTypes.Query()).ConfigureAwait(false);
    }
}
