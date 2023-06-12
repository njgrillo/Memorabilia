namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ItemTypeSizeEditor 
    : EditItemTypeItem<ItemTypeSizeEditModel, ItemTypeSizeModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSize(EditModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = (await QueryRouter.Send(new GetItemTypeSize(Id))).ToEditModel();
    }
}
