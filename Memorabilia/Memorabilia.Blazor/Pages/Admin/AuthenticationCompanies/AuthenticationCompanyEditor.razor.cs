#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class AuthenticationCompanyEditor : EditDomainItem<AuthenticationCompany>, IEditDomainItem
{
    //private const string DomainTypeName = "Authenticaton Company";
    //private const string ImagePath = "images/authenticationcompanies.jpg";
    //private const string NavigationPath = "AuthenticationCompanies";

    public async Task OnLoad()
    {
        await OnLoad(new GetAuthenticationCompany.Query(Id));
    }

    public async Task OnSave()
    {

        await OnSave(new SaveAuthenticationCompany.Command(ViewModel));
    }
}
