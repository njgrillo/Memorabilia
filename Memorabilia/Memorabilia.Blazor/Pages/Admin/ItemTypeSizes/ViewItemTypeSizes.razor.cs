namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ViewItemTypeSizes : ViewItem<ItemTypeSizesViewModel, ItemTypeSizeViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetItemTypeSizes());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSizes.Single(ItemTypeSize => ItemTypeSize.Id == id);
        var viewModel = new SaveItemTypeSizeViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSize(viewModel));

        ViewModel.ItemTypeSizes.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSizeViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
