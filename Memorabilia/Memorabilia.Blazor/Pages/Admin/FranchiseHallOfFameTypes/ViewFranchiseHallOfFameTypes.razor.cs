namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class ViewFranchiseHallOfFameTypes 
    : ViewDomainItem<FranchiseHallOfFameTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFranchiseHallOfFameType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new FranchiseHallOfFameTypesModel(await QueryRouter.Send(new GetFranchiseHallOfFameTypes()));
    }
}
