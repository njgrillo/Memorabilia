namespace Memorabilia.Blazor.Controls.Images;

public partial class ImagePanel
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public string[] ImageNames { get; set; }

    [Parameter]
    public string PanelText { get; set; }

    [Parameter]
    public int UserId { get; set; }
}
