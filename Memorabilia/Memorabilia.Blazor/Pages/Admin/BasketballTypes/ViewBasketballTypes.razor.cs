namespace Memorabilia.Blazor.Pages.Admin.BasketballTypes;

public partial class ViewBasketballTypes 
    : ViewDomainItem<BasketballTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveBasketballType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new BasketballTypesModel(await QueryRouter.Send(new GetBasketballTypes()));
    }
}
