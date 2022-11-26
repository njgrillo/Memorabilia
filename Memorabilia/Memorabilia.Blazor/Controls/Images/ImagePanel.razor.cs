#nullable disable

namespace Memorabilia.Blazor.Controls.Images;

public partial class ImagePanel : ImagePage
{
    [Parameter]
    public string[] ImageNames { get; set; }

    [Parameter]
    public string PanelText { get; set; }
}
