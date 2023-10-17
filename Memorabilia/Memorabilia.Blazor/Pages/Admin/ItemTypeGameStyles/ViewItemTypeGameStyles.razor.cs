namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ViewItemTypeGameStyles 
    : ViewItem<ItemTypeGameStylesModel, ItemTypeGameStyleModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new ItemTypeGameStylesModel(await Mediator.Send(new GetItemTypeGameStyles()));
    }

    protected override async Task Delete(int id)
    {
        ItemTypeGameStyleModel deletedItem 
            = Model.ItemTypeGameStyles.Single(itemTypeGameStyle => itemTypeGameStyle.Id == id);

        var editModel = new ItemTypeGameStyleEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveItemTypeGameStyle(editModel));

        Model.ItemTypeGameStyles.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeGameStyleModel model, string search)
        => search.IsNullOrEmpty() ||
           model.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.GameStyleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
