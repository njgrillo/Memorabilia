#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class ViewFranchiseHallOfFameTypes : ViewDomainItem<FranchiseHallOfFameTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveFranchiseHallOfFameType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetFranchiseHallOfFameTypes.Query());
    }
}
