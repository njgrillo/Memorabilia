namespace Memorabilia.Blazor.Controls.Switches;

public partial class Switch
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Parameter]
    public bool Checked { get; set; }

    [Parameter]
    public EventCallback<bool> CheckedChanged { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public string Label { get; set; }

    private string _style;

    protected override void OnInitialized()
    {
        _style = ApplicationStateService.IsDarkTheme
            ? "color:white;"
            : "color:black";
    }
}
