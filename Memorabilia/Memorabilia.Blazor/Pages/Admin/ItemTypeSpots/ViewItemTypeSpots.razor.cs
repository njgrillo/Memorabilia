namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ViewItemTypeSpots : ViewItem<ItemTypeSpotsViewModel, ItemTypeSpotViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetItemTypeSpots());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSpots.Single(ItemTypeSpot => ItemTypeSpot.Id == id);
        var viewModel = new SaveItemTypeSpotViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSpot(viewModel));

        ViewModel.ItemTypeSpots.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSpotViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.SpotName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
