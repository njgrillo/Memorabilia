namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ItemTypeGameStyleEditor 
    : EditItem<ItemTypeGameStyleEditModel, ItemTypeGameStyleModel>
{
    protected override async Task OnInitializedAsync()
    {
        EditModel = (await Mediator.Send(new GetItemTypeGameStyle(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveItemTypeGameStyle(EditModel));
    }
}
