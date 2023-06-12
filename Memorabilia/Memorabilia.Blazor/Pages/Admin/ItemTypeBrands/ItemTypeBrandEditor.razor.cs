namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ItemTypeBrandEditor 
    : EditItemTypeItem<ItemTypeBrandEditModel, ItemTypeBrandModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeBrand(EditModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = new ItemTypeBrandEditModel(new ItemTypeBrandModel(await QueryRouter.Send(new GetItemTypeBrand(Id))));
    }
}
