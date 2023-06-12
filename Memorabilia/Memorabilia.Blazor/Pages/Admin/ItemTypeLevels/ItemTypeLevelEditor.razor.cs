namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ItemTypeLevelEditor : EditItemTypeItem<ItemTypeLevelEditModel, ItemTypeLevelModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeLevel(EditModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = new ItemTypeLevelEditModel(new ItemTypeLevelModel(await QueryRouter.Send(new GetItemTypeLevel(Id))));
    }
}
