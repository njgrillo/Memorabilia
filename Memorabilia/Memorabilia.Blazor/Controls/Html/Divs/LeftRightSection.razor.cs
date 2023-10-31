namespace Memorabilia.Blazor.Controls.Html.Divs;

public partial class LeftRightSection
{
    [Parameter]
    public RenderFragment Left { get; set; }

    [Parameter]
    public string LeftClass { get; set; }

    [Parameter]
    public string LeftStyle { get; set; }

    [Parameter]
    public RenderFragment Right { get; set; }

    [Parameter]
    public string RightClass { get; set; }

    [Parameter]
    public string RightStyle { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
