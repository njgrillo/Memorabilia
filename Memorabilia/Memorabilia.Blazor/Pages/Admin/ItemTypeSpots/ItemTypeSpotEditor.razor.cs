namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ItemTypeSpotEditor 
    : EditItemTypeItem<ItemTypeSpotEditModel, ItemTypeSpotModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSpot(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = (await QueryRouter.Send(new GetItemTypeSpot(Id))).ToEditModel();
    }
}
