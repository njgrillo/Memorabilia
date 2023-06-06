namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class ViewBrands : ViewDomainItem<BrandsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveBrand(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBrands());
    }
}
