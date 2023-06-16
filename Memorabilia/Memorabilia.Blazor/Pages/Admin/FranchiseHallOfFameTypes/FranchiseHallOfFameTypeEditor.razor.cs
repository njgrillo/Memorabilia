namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class FranchiseHallOfFameTypeEditor 
    : EditDomainItem<FranchiseHallOfFameType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetFranchiseHallOfFameType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFranchiseHallOfFameType(EditModel));
    }
}
