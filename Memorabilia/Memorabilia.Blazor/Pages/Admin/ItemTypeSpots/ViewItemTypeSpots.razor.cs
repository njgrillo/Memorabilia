namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ViewItemTypeSpots 
    : ViewItem<ItemTypeSpotsModel, ItemTypeSpotModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new ItemTypeSpotsModel(await QueryRouter.Send(new GetItemTypeSpots()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSpots.Single(ItemTypeSpot => ItemTypeSpot.Id == id);
        var viewModel = new ItemTypeSpotEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSpot(viewModel));

        ViewModel.ItemTypeSpots.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSpotModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.SpotName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
