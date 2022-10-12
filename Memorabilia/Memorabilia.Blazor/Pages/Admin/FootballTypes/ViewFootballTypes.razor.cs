#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class ViewFootballTypes : ViewDomainItem<FootballTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveFootballType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFootballTypes.Query()).ConfigureAwait(false);
    }
}
