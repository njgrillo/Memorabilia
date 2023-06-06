namespace Memorabilia.Blazor.Pages.Admin.ItemTypes;

public partial class ViewItemTypes : ViewDomainItem<ItemTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveItemType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetItemTypes());
    }
}
