#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ViewColors : ViewDomainItem<ColorsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveColor.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetColors.Query()).ConfigureAwait(false);
    }
}
