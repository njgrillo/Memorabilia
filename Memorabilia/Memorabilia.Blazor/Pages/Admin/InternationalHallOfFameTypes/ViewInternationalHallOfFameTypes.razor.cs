#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.InternationalHallOfFameTypes;

public partial class ViewInternationalHallOfFameTypes : ViewDomainItem<InternationalHallOfFameTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveInternationalHallOfFameType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetInternationalHallOfFameTypes.Query()).ConfigureAwait(false);
    }
}
