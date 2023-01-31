namespace Memorabilia.Blazor.Controls.Alerts;

public partial class AlertBox
{
    [Parameter]
    public Severity Severity { get; set; }

    [Parameter]
    public string Text { get; set; }
}
