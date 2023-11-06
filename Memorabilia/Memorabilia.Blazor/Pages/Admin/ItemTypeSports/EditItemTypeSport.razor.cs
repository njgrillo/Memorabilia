namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class EditItemTypeSport
    : EditItem<ItemTypeSportEditModel, ItemTypeSportModel>
{   
    protected override async Task OnInitializedAsync()
    {
        EditModel = (await Mediator.Send(new GetItemTypeSport(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveItemTypeSport(EditModel));
    }
}
