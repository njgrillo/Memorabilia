namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ItemTypeSpotEditor 
    : EditItem<ItemTypeSpotEditModel, ItemTypeSpotModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSpot(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeSpot(Id))).ToEditModel();
    }
}
