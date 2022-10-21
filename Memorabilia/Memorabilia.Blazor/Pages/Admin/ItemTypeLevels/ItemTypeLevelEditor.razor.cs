namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ItemTypeLevelEditor : EditItemTypeItem<SaveItemTypeLevelViewModel, ItemTypeLevelViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeLevel(ViewModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        ViewModel = new SaveItemTypeLevelViewModel(await Get(new GetItemTypeLevel(Id)));
    }
}
