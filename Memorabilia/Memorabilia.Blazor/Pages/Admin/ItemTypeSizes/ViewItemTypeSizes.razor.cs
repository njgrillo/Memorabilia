namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ViewItemTypeSizes 
    : ViewItem<ItemTypeSizesModel, ItemTypeSizeModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new ItemTypeSizesModel(await QueryRouter.Send(new GetItemTypeSizes()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSizes.Single(ItemTypeSize => ItemTypeSize.Id == id);
        var viewModel = new ItemTypeSizeEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSize(viewModel));

        ViewModel.ItemTypeSizes.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSizeModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
