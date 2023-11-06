namespace Memorabilia.Blazor.Controls.Grids.Toolbar;

public partial class ToolbarTitle
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Text { get; set; }
}
