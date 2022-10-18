namespace Memorabilia.Blazor.Pages.Admin.PurchaseTypes;

public partial class PurchaseTypeEditor : EditDomainItem<PurchaseType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetPurchaseType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePurchaseType(ViewModel));
    }
}
