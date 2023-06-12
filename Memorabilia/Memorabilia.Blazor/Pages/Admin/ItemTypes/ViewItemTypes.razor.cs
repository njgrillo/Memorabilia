namespace Memorabilia.Blazor.Pages.Admin.ItemTypes;

public partial class ViewItemTypes 
    : ViewDomainItem<ItemTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveItemType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new ItemTypesModel(await QueryRouter.Send(new GetItemTypes()));
    }
}
