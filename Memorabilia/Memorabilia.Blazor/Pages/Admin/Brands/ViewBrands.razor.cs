namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class ViewBrands 
    : ViewDomainItem<BrandsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveBrand(editModel));
    }

    public async Task OnLoad()
    {
        Model = new BrandsModel(await QueryRouter.Send(new GetBrands()));
    }
}
