namespace Memorabilia.Blazor.Controls.Html.Divs;

public partial class DivRowCol12Center
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool IncludePageBreakAtEnd { get; set; }
        = true;
}
