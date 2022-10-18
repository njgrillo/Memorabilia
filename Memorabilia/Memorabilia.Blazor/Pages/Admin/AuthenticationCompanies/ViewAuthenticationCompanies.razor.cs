namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class ViewAuthenticationCompanies : ViewDomainItem<AuthenticationCompaniesViewModel>, IViewDomainItem, IDeleteDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveAuthenticationCompany(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetAuthenticationCompanies());
    }
}
