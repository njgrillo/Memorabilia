namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ItemTypeBrandEditor 
    : EditItem<ItemTypeBrandEditModel, ItemTypeBrandModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeBrand(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeBrand(Id))).ToEditModel();
    }
}
