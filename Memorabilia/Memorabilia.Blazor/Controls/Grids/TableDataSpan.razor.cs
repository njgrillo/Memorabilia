namespace Memorabilia.Blazor.Controls.Grids;

public partial class TableDataSpan
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Colspan { get; set; }
        = "17";
}
