namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ItemTypeSportEditor 
    : EditItem<ItemTypeSportEditModel, ItemTypeSportModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSport(EditModel));
    }

    protected override async Task OnInitializedAsync()
    {
        EditModel = (await QueryRouter.Send(new GetItemTypeSport(Id))).ToEditModel();
    }
}
