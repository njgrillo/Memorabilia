namespace Memorabilia.Web.Shared;

public partial class MainLayout : LayoutComponentBase
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    private Exception _currentException;

    private bool _drawerOpen 
        = true;

    private CustomErrorBoundary _errorBoundary;

    private string _themeText
        = "Turn on dark mode";

    protected override void OnInitialized()
    {
        Courier.Subscribe<ThemeChangedNotification>(OnThemeChanged);
    }

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

    public async Task OnThemeChanged(ThemeChangedNotification notification)
    {
        SetThemeText();

        await InvokeAsync(StateHasChanged);
    }

    public void ToggleTheme()
    {
        ApplicationStateService.IsDarkTheme = !ApplicationStateService.IsDarkTheme;

        SetThemeText();
    }

    public void UserSettings()
    {
        NavigationManager.NavigateTo("Settings");
    }

    private void SetThemeText()
    {
        _themeText = ApplicationStateService.IsDarkTheme
            ? "Turn off dark mode"
            : "Turn on dark mode";
    }
}
