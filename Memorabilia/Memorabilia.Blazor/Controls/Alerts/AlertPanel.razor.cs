namespace Memorabilia.Blazor.Controls.Alerts;

public partial class AlertPanel
{
    [Parameter]
    public Alert[] Alerts { get; set; }

    [Parameter]
    public string DivStyle { get; set; }
        = $"{Style.BorderBlack}{Style.MarginPad2}";

    [Parameter]
    public bool ShowCloseIcon { get; set; }
        = true;    
}
