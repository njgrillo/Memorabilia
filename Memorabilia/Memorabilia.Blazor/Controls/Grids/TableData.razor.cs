namespace Memorabilia.Blazor.Controls.Grids;

public partial class TableData
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string DataLabel { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
