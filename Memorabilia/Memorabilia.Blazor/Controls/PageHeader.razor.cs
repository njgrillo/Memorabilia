namespace Memorabilia.Blazor.Controls;

public partial class PageHeader : ThemedControl
{
    [Parameter]
    public string PageTitle { get; set; }

    private string _style;

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
        _style = ApplicationStateService.IsDarkMode
            ? "color:white;"
            : string.Empty;

        StateHasChanged();
    }
}
