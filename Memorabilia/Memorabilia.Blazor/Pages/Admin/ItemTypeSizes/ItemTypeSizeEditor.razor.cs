namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ItemTypeSizeEditor : EditItemTypeItem<ItemTypeSizeEditModel, ItemTypeSizeModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSize(ViewModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        ViewModel = new ItemTypeSizeEditModel(new ItemTypeSizeModel(await QueryRouter.Send(new GetItemTypeSize(Id))));
    }
}
