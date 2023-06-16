namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class ViewFranchiseHallOfFameTypes 
    : ViewDomainItem<FranchiseHallOfFameTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveFranchiseHallOfFameType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new FranchiseHallOfFameTypesModel(await QueryRouter.Send(new GetFranchiseHallOfFameTypes()));
    }
}
