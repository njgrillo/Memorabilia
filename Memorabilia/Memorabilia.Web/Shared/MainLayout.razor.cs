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

    private string _theme;

    private string _themeText
        = "Turn on dark mode";

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

    public void ToggleTheme()
    {
        ApplicationStateService.IsDarkMode = !ApplicationStateService.IsDarkMode;    

        _theme = ApplicationStateService.IsDarkMode
            ? "background-color:dimgray;"
            : string.Empty;

        _themeText = ApplicationStateService.IsDarkMode
            ? "Turn off dark mode"
            : "Turn on dark mode";
    }

    public void UserSettings()
    {
        NavigationManager.NavigateTo("Settings");
    }
}
