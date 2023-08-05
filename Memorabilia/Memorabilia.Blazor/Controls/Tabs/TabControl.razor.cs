namespace Memorabilia.Blazor.Controls.Tabs;

public partial class TabControl : ThemedControl
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private Color _color;

    protected override void OnInitialized()
    {
        SetTheme();

        base.OnInitialized();
    }
    
    public override void OnThemeChanged()
    {
        SetTheme();
    }

    private void SetTheme()
    {
        _color = ApplicationStateService.IsDarkMode
            ? Color.Dark
            : Color.Default;

        StateHasChanged();
    }
}
