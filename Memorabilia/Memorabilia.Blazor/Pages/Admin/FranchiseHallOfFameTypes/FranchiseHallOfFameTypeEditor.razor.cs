namespace Memorabilia.Blazor.Pages.Admin.FranchiseHallOfFameTypes;

public partial class FranchiseHallOfFameTypeEditor : EditDomainItem<FranchiseHallOfFameType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetFranchiseHallOfFameType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveFranchiseHallOfFameType(Model));
    }
}
