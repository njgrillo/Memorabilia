namespace Memorabilia.Web.Shared;

public partial class MainLayout : LayoutComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private bool _drawerOpen = true;

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

    public void UserSettings()
    {
        NavigationManager.NavigateTo("Settings");
    }
}
