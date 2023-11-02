namespace Memorabilia.Blazor.Controls.Alerts;

public partial class AlertPanel
{
    [Parameter]
    public Alert[] Alerts { get; set; }

    [Parameter]
    public bool ShowCloseIcon { get; set; }
        = true;
}
