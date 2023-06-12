namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class ViewBrands 
    : ViewDomainItem<BrandsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveBrand(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new BrandsModel(await QueryRouter.Send(new GetBrands()));
    }
}
