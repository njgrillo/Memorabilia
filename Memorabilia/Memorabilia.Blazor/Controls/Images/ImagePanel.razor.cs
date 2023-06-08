namespace Memorabilia.Blazor.Controls.Images;

public partial class ImagePanel
{
    [Parameter]
    public string[] ImageNames { get; set; }

    [Parameter]
    public string PanelText { get; set; }

    [Parameter]
    public int UserId { get; set; }
}
