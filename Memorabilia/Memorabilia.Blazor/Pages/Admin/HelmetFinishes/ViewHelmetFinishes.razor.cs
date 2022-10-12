#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.HelmetFinishes;

public partial class ViewHelmetFinishes : ViewDomainItem<HelmetFinishesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveHelmetFinish.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetHelmetFinishes.Query()).ConfigureAwait(false);
    }
}
