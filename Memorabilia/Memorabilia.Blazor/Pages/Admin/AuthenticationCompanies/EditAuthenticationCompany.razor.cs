namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class EditAuthenticationCompany
    : EditDomainItem<AuthenticationCompany>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetAuthenticationCompany(Id));
    }

    public async Task OnSave()
    {

        await OnSave(new SaveAuthenticationCompany(EditModel));
    }
}
