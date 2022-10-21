namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ItemTypeBrandEditor : EditItemTypeItem<SaveItemTypeBrandViewModel, ItemTypeBrandViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeBrand(ViewModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        ViewModel = new SaveItemTypeBrandViewModel(await Get(new GetItemTypeBrand(Id)));
    }
}
