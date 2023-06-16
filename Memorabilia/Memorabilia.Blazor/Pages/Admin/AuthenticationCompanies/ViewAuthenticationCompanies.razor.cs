namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class ViewAuthenticationCompanies 
    : ViewDomainItem<AuthenticationCompaniesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAuthenticationCompany(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new AuthenticationCompaniesModel(await QueryRouter.Send(new GetAuthenticationCompanies()));
    }
}
