namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ItemTypeSportEditor 
    : EditItemTypeItem<ItemTypeSportEditModel, ItemTypeSportModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSport(EditModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = new ItemTypeSportEditModel(new ItemTypeSportModel(await QueryRouter.Send(new GetItemTypeSport(Id))));
    }
}
