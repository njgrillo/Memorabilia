#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.HelmetQualityTypes;

public partial class ViewHelmetQualityTypes : ViewDomainItem<HelmetQualityTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveHelmetQualityType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetHelmetQualityTypes.Query()).ConfigureAwait(false);
    }
}
