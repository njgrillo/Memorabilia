namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class ItemTypeSizeEditor 
    : EditItem<ItemTypeSizeEditModel, ItemTypeSizeModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSize(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeSize(Id))).ToEditModel();
    }
}
