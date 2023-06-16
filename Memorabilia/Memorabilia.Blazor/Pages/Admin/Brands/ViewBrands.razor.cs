namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class ViewBrands 
    : ViewDomainItem<BrandsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveBrand(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new BrandsModel(await QueryRouter.Send(new GetBrands()));
    }
}
