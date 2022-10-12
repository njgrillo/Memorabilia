#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class ViewJerseyTypes : ViewDomainItem<JerseyTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyTypes.Query()).ConfigureAwait(false);
    }
}
