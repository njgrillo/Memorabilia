namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ItemTypeSizeEditor : EditItemTypeItem<SaveItemTypeSizeViewModel, ItemTypeSizeViewModel>
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

        ViewModel = new SaveItemTypeSizeViewModel(await Get(new GetItemTypeSize(Id)));
    }
}
