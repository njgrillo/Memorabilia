namespace Memorabilia.Web.Shared;

public partial class MainLayout : LayoutComponentBase
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private Exception _currentException;

    private bool _drawerOpen 
        = true;

    private CustomErrorBoundary _errorBoundary;

    protected override void OnParametersSet()
    {
        _errorBoundary?.Recover();
    }

    public void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    public void OnAlertClose()
    {
        _currentException = null;
    }

    public void OnError(Exception error) 
    {
        _currentException = error;

        string url = ApplicationStateService.CurrentUser == null
            ? "/"
            : "Home";

        NavigationManager.NavigateTo(url);
    }

    public void UserSettings()
    {
        NavigationManager.NavigateTo("Settings");
    }
}
