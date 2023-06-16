namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ItemTypeLevelEditor 
    : EditItemTypeItem<ItemTypeLevelEditModel, ItemTypeLevelModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeLevel(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = (await QueryRouter.Send(new GetItemTypeLevel(Id))).ToEditModel();
    }
}
