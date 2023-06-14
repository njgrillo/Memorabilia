namespace Memorabilia.Web.Pages;

public partial class Default
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }   

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (ApplicationStateService.CurrentUser != null)
            return;

        AuthenticationState state = await AuthenticationStateProvider.GetAuthenticationStateAsync();

        string emailAddress = state.User
                                   .Claims
                                   .SingleOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value 
                                   ?? string.Empty;

        if (emailAddress.IsNullOrEmpty()) 
            return;

        Entity.User user = await QueryRouter.Send(new GetUser(emailAddress));

        if (user == null) 
            return;

        ApplicationStateService.Set(user);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (ApplicationStateService.CurrentUser == null)
            return;

        NavigationManager.NavigateTo("Home");
    }
}
