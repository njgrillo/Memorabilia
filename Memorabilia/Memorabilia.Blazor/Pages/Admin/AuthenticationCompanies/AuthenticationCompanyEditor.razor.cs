namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class AuthenticationCompanyEditor : EditDomainItem<AuthenticationCompany>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetAuthenticationCompany(Id));
    }

    public async Task OnSave()
    {

        await OnSave(new SaveAuthenticationCompany(EditModel));
    }
}
