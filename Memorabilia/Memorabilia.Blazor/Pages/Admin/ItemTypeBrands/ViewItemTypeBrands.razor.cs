namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ViewItemTypeBrands 
    : ViewItem<ItemTypeBrandsModel, ItemTypeBrandModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new ItemTypeBrandsModel(await Mediator.Send(new GetItemTypeBrands()));
    }

    protected override async Task Delete(int id)
    {
        ItemTypeBrandModel deletedItem = Model.ItemTypeBrands.Single(ItemTypeBrand => ItemTypeBrand.Id == id);

        var editModel = new ItemTypeBrandEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Save(new SaveItemTypeBrand(editModel));

        Model.ItemTypeBrands.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeBrandModel model, string search)
        => search.IsNullOrEmpty() ||
           model.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.BrandName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
