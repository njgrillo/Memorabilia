namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class ViewAuthenticationCompanies 
    : ViewDomainItem<AuthenticationCompaniesModel>, IViewDomainItem, IDeleteDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAuthenticationCompany(editModel));
    }

    public async Task OnLoad()
    {
        Model = new AuthenticationCompaniesModel(await QueryRouter.Send(new GetAuthenticationCompanies()));
    }
}
