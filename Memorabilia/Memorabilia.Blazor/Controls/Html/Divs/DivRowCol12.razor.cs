namespace Memorabilia.Blazor.Controls.Html.Divs;

public partial class DivRowCol12
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
