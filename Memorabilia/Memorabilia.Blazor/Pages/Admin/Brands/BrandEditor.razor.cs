namespace Memorabilia.Blazor.Pages.Admin.Brands;

public partial class BrandEditor 
    : EditDomainItem<Brand>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetBrand(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBrand(EditModel));
    }
}
