#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.FootballTypes;

public partial class ViewFootballTypes : ComponentBase, IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private FootballTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveFootballType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFootballTypes.Query()).ConfigureAwait(false);
    }
}
