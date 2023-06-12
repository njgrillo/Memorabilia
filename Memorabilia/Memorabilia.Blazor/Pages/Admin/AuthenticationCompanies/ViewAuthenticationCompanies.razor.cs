namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class ViewAuthenticationCompanies : ViewDomainItem<AuthenticationCompaniesModel>, IViewDomainItem, IDeleteDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveAuthenticationCompany(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new AuthenticationCompaniesModel(await QueryRouter.Send(new GetAuthenticationCompanies()));
    }
}
