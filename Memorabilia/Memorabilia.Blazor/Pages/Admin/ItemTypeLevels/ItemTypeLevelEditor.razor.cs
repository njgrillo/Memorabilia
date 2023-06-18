namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ItemTypeLevelEditor 
    : EditItem<ItemTypeLevelEditModel, ItemTypeLevelModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeLevel(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeLevel(Id))).ToEditModel();
    }
}
