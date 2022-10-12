#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class ViewJerseyStyleTypes : ViewDomainItem<JerseyStyleTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyStyleType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyStyleTypes.Query()).ConfigureAwait(false);
    }
}
