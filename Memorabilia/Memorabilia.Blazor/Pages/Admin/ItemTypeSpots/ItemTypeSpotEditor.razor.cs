namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ItemTypeSpotEditor : EditItemTypeItem<SaveItemTypeSpotViewModel, ItemTypeSpotViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSpot(ViewModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        ViewModel = new SaveItemTypeSpotViewModel(await Get(new GetItemTypeSpot(Id)));
    }
}
