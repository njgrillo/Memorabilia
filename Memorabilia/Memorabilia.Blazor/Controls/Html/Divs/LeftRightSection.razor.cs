namespace Memorabilia.Blazor.Controls.Html.Divs;

public partial class LeftRightSection
{
    [Parameter]
    public RenderFragment Left { get; set; }

    [Parameter]
    public RenderFragment Right { get; set; }
}
