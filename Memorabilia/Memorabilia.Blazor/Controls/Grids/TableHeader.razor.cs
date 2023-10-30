namespace Memorabilia.Blazor.Controls.Grids;

public partial class TableHeader
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
