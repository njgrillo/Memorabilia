namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class ViewFranchiseHallOfFameTypes 
    : ViewDomainItem<FranchiseHallOfFameTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveFranchiseHallOfFameType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new FranchiseHallOfFameTypesModel(await QueryRouter.Send(new GetFranchiseHallOfFameTypes()));
    }
}
