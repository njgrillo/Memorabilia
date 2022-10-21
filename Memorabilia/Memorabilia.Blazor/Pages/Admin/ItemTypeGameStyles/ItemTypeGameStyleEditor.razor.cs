namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ItemTypeGameStyleEditor : EditItemTypeItem<SaveItemTypeGameStyleViewModel, ItemTypeGameStyleViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeGameStyle(ViewModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        ViewModel = new SaveItemTypeGameStyleViewModel(await Get(new GetItemTypeGameStyle(Id)));
    }
}
