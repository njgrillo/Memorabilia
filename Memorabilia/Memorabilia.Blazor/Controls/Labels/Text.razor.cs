namespace Memorabilia.Blazor.Controls.Labels;

public partial class Text
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Parameter]
    public string Content { get; set; }

    private string _style;

    protected override void OnInitialized()
    {
        _style = ApplicationStateService.IsDarkMode
            ? "color:white;"
            : string.Empty;
    }
}
