namespace Memorabilia.Blazor.Controls.Tabs;

public partial class TabControl
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private Color _color;

    protected override void OnInitialized()
    {
        _color = ApplicationStateService.IsDarkMode
            ? Color.Dark
            : Color.Default;
    }
}
