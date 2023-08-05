namespace Memorabilia.Web.Shared;

public partial class NavMenu
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    private string _theme;

    protected override void OnInitialized()
    {
        _theme = ApplicationStateService.IsDarkMode
            ? "background-color:dimgray;color:white;"
            : string.Empty;
    }
}
