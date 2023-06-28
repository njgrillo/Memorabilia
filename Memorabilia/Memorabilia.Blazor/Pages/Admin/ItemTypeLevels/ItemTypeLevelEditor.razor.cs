namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ItemTypeLevelEditor 
    : EditItem<ItemTypeLevelEditModel, ItemTypeLevelModel>
{
    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeLevel(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveItemTypeLevel(EditModel));
    }
}
