namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class ViewBasketballTypes : ViewDomainItem<BasketballTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveBasketballType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new BasketballTypesModel(await QueryRouter.Send(new GetBasketballTypes()));
    }
}
