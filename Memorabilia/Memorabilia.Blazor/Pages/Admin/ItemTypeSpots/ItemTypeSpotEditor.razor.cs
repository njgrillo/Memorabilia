namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ItemTypeSpotEditor 
    : EditItem<ItemTypeSpotEditModel, ItemTypeSpotModel>
{
    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeSpot(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveItemTypeSpot(EditModel));
    }
}
