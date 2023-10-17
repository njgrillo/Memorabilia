namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class ViewBrands 
    : ViewDomainItem<BrandsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveBrand(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new BrandsModel(await Mediator.Send(new GetBrands()));
    }
}
