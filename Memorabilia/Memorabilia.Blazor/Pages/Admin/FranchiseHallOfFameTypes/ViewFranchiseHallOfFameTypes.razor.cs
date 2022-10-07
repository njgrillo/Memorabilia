#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class ViewFranchiseHallOfFameTypes : ComponentBase, IViewDomainItem, IDeleteDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private FranchiseHallOfFameTypesViewModel ViewModel;

    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveFranchiseHallOfFameType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFranchiseHallOfFameTypes.Query()).ConfigureAwait(false);
    }
}
