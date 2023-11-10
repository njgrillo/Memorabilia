namespace Memorabilia.Blazor.Controls.Alerts;

public partial class AlertBox
{
    [Parameter]
    public EventCallback Close { get; set; }

    [Parameter]
    public Severity Severity { get; set; }

    [Parameter]
    public bool ShowCloseIcon { get; set; }
        = true;

    [Parameter]
    public string Text { get; set; }

    protected async Task CloseClicked()
    {
        await Close.InvokeAsync();
    }
}
