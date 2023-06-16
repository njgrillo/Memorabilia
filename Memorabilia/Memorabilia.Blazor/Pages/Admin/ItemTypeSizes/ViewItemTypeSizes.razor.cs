namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ViewItemTypeSizes 
    : ViewItem<ItemTypeSizesModel, ItemTypeSizeModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new ItemTypeSizesModel(await QueryRouter.Send(new GetItemTypeSizes()));
    }

    protected override async Task Delete(int id)
    {
        ItemTypeSizeModel deletedItem 
            = Model.ItemTypeSizes.Single(ItemTypeSize => ItemTypeSize.Id == id);

        var editModel = new ItemTypeSizeEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSize(editModel));

        Model.ItemTypeSizes.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSizeModel model, string search)
        => search.IsNullOrEmpty() ||
           model.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
