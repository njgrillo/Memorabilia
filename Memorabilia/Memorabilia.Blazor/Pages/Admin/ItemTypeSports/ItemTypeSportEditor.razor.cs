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

        EditModel = (await QueryRouter.Send(new GetItemTypeSport(Id))).ToEditModel();
    }
}
