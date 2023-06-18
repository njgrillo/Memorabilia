namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ItemTypeGameStyleEditor 
    : EditItem<ItemTypeGameStyleEditModel, ItemTypeGameStyleModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeGameStyle(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeGameStyle(Id))).ToEditModel();
    }
}
