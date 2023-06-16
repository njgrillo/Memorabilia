namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ItemTypeSizeEditor 
    : EditItemTypeItem<ItemTypeSizeEditModel, ItemTypeSizeModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSize(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = (await QueryRouter.Send(new GetItemTypeSize(Id))).ToEditModel();
    }
}
