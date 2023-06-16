namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ItemTypeGameStyleEditor 
    : EditItemTypeItem<ItemTypeGameStyleEditModel, ItemTypeGameStyleModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeGameStyle(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Initialize();

        if (DisplayItemType)
            return;

        EditModel = (await QueryRouter.Send(new GetItemTypeGameStyle(Id))).ToEditModel();
    }
}
