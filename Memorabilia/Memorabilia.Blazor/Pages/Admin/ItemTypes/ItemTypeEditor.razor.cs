namespace Memorabilia.Blazor.Pages.Admin.ItemTypes;

public partial class ItemTypeEditor : EditDomainItem<ItemType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetItemType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveItemType(Model));
    }
}
