namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ViewItemTypeGameStyles 
    : ViewItem<ItemTypeGameStylesModel, ItemTypeGameStyleModel>
{
    protected async Task OnLoad()
    {
        Model = new ItemTypeGameStylesModel(await QueryRouter.Send(new GetItemTypeGameStyles()));
    }

    protected override async Task Delete(int id)
    {
        ItemTypeGameStyleModel deletedItem 
            = Model.ItemTypeGameStyles.Single(itemTypeGameStyle => itemTypeGameStyle.Id == id);

        var editModel = new ItemTypeGameStyleEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeGameStyle(editModel));

        Model.ItemTypeGameStyles.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeGameStyleModel model, string search)
        => search.IsNullOrEmpty() ||
           model.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.GameStyleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
