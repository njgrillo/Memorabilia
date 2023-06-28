namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ItemTypeBrandEditor 
    : EditItem<ItemTypeBrandEditModel, ItemTypeBrandModel>
{
    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeBrand(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveItemTypeBrand(EditModel));
    }
}
