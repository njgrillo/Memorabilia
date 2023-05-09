namespace Memorabilia.Web.Shared;

public partial class MainLayout : LayoutComponentBase
{
    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private bool _drawerOpen = true;
    private ErrorBoundary _errorBoundary;
    private bool _userLoggedIn;

    protected override void OnInitialized()
    {
        Courier.Subscribe<UserLoggedInNotification>(OnUserLoginAsync);
    }

    protected override void OnParametersSet()
    {
        _errorBoundary?.Recover();
    }

    public void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    public void Login()
    {
        NavigationManager.NavigateTo("Login");
    }

    public void Logout()
    {
        NavigationManager.NavigateTo("Logout");
    }

    public async void OnUserLoginAsync(UserLoggedInNotification notification)
    {
        _userLoggedIn = true;

        await InvokeAsync(() =>
        {
            StateHasChanged();
        });        
    }

    public void UserSettings()
    {
        NavigationManager.NavigateTo("Settings");
    }
}
