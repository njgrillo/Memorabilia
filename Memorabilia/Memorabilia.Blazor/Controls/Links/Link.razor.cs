namespace Memorabilia.Blazor.Controls.Links;

public partial class Link
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Href { get; set; }

    [Parameter]
    public string Target { get; set; }

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
