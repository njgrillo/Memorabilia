namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class BrandEditor : EditDomainItem<Brand>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetBrand(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBrand(ViewModel));
    }
}
