#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ViewItemTypeBrands : ViewItem<ItemTypeBrandsViewModel, ItemTypeBrandViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetItemTypeBrands());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeBrands.Single(ItemTypeBrand => ItemTypeBrand.Id == id);
        var viewModel = new SaveItemTypeBrandViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await Save(new SaveItemTypeBrand(viewModel));

        ViewModel.ItemTypeBrands.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeBrandViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.BrandName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
