namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ViewItemTypeLevels 
    : ViewItem<ItemTypeLevelsModel, ItemTypeLevelModel>
{
    protected async Task OnLoad()
    {
        Model = new ItemTypeLevelsModel(await QueryRouter.Send(new GetItemTypeLevels()));
    }

    protected override async Task Delete(int id)
    {
        ItemTypeLevelModel deletedItem 
            = Model.ItemTypeLevels.Single(ItemTypeLevel => ItemTypeLevel.Id == id);

        var editModel = new ItemTypeLevelEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeLevel(editModel));

        Model.ItemTypeLevels.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeLevelModel model, string search)
        => search.IsNullOrEmpty() ||
           model.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
