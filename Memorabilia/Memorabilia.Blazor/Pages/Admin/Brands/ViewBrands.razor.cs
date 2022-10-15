#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class ViewBrands : ViewDomainItem<BrandsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveBrand.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetBrands.Query());
    }
}
