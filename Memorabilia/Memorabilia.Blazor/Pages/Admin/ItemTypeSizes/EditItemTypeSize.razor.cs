namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSizes;

public partial class EditItemTypeSize
    : EditItem<ItemTypeSizeEditModel, ItemTypeSizeModel>
{
    protected override async Task OnInitializedAsync()
    {
        EditModel = (await Mediator.Send(new GetItemTypeSize(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveItemTypeSize(EditModel));
    }
}
