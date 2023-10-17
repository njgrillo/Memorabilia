namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class ViewFranchiseHallOfFameTypes 
    : ViewDomainItem<FranchiseHallOfFameTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveFranchiseHallOfFameType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new FranchiseHallOfFameTypesModel(await Mediator.Send(new GetFranchiseHallOfFameTypes()));
    }
}
