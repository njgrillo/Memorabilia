namespace Memorabilia.Blazor.Pages.Admin.BatTypes;

public partial class BatTypeEditor : EditDomainItem<BatType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetBatType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBatType.Command(ViewModel));
    }
}
