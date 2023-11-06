namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class EditItemTypeLevel
    : EditItem<ItemTypeLevelEditModel, ItemTypeLevelModel>
{
    protected override async Task OnInitializedAsync()
    {
        EditModel = (await Mediator.Send(new GetItemTypeLevel(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveItemTypeLevel(EditModel));
    }
}
