#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.GloveTypes;

public partial class ViewGloveTypes : ViewDomainItem<GloveTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveGloveType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetGloveTypes.Query()).ConfigureAwait(false);
    }
}
