#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.AuthenticationCompanies;

public partial class AuthenticationCompanyEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }        

    private const string DomainTypeName = "Authenticaton Company";
    private const string ImagePath = "images/authenticationcompanies.jpg";
    private const string NavigationPath = "AuthenticationCompanies";
    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetAuthenticationCompany.Query(Id)).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveAuthenticationCompany.Command(ViewModel)).ConfigureAwait(false);
    }
}
