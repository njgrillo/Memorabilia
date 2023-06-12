namespace Memorabilia.Blazor.Pages.Admin.ItemTypes;

public partial class ViewItemTypes 
    : ViewDomainItem<ItemTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveItemType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new ItemTypesModel(await QueryRouter.Send(new GetItemTypes()));
    }
}
