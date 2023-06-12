namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ItemTypeGameStyleEditor : EditItemTypeItem<ItemTypeGameStyleEditModel, ItemTypeGameStyleModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeGameStyle(EditModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = new ItemTypeGameStyleEditModel(new ItemTypeGameStyleModel(await QueryRouter.Send(new GetItemTypeGameStyle(Id))));
    }
}
