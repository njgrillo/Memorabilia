namespace Memorabilia.Blazor.Controls.IFrames;

public partial class IFrame
{
    [Parameter]
    public string Height { get; set; }
        = "50%";

    [Parameter]
    public string Source { get; set; }

    [Parameter]
    public string Width { get; set; }
        = "90%";
}
