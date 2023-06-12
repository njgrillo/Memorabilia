namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ViewItemTypeBrands 
    : ViewItem<ItemTypeBrandsModel, ItemTypeBrandModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new ItemTypeBrandsModel(await QueryRouter.Send(new GetItemTypeBrands()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeBrands.Single(ItemTypeBrand => ItemTypeBrand.Id == id);
        var viewModel = new ItemTypeBrandEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Save(new SaveItemTypeBrand(viewModel));

        ViewModel.ItemTypeBrands.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeBrandModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.BrandName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
