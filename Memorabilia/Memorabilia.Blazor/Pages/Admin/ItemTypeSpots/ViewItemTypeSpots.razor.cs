namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ViewItemTypeSpots 
    : ViewItem<ItemTypeSpotsModel, ItemTypeSpotModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new ItemTypeSpotsModel(await Mediator.Send(new GetItemTypeSpots()));
    }

    protected override async Task Delete(int id)
    {
        ItemTypeSpotModel deletedItem 
            = Model.ItemTypeSpots.Single(ItemTypeSpot => ItemTypeSpot.Id == id);

        var editModel = new ItemTypeSpotEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveItemTypeSpot(editModel));

        Model.ItemTypeSpots.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSpotModel model, string search)
        => search.IsNullOrEmpty() ||
           model.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.SpotName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
