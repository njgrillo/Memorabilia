namespace Memorabilia.Blazor.Controls;

public partial class HiddenControl
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
