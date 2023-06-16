namespace Memorabilia.Blazor.Pages.Admin.ItemTypes;

public partial class ItemTypeEditor 
    : EditDomainItem<ItemType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetItemType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveItemType(EditModel));
    }
}
