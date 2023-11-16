using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Web.Components.Pages;

public partial class Default
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }   

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public LoginProviderService LoginProviderService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Courier.Subscribe<UserSubscriptionChangedNotification>(OnSubscriptionChanged);

        if (ApplicationStateService.CurrentUser != null)
            return;

        AuthenticationState state 
            = await AuthenticationStateProvider.GetAuthenticationStateAsync();

        bool isAuthenticated = state.User.Identities.FirstOrDefault()?.IsAuthenticated ?? false;

        if (!isAuthenticated)
            return;

        string providerName = state.User.Identity.AuthenticationType;

        var provider = LoginProvider.Find(providerName);

        if (provider == null)
            return;

        ApplicationStateService.Provider = provider; 

        Entity.User user
            = await LoginProviderService.GetUser(state, ApplicationStateService.Provider);

        if (user == null)
            return;

        ApplicationStateService.Set(user);
    }

    protected override void OnAfterRender(bool firstRender)
    {
        if (ApplicationStateService.CurrentUser == null)
        {
            NavigationManager.NavigateTo("/logout", true);
            return;
        }

        NavigationManager.NavigateTo("Home");
    }

    public async Task OnSubscriptionChanged(UserSubscriptionChangedNotification notification)
    {
        AuthenticationState state
            = await AuthenticationStateProvider.GetAuthenticationStateAsync();

        bool isAuthenticated = state.User.Identities.FirstOrDefault()?.IsAuthenticated ?? false;

        if (!isAuthenticated)
            return;

        Entity.User user
            = await LoginProviderService.GetUser(state, ApplicationStateService.Provider);

        if (user == null)
            return;

        ApplicationStateService.Set(user);
    }
}
