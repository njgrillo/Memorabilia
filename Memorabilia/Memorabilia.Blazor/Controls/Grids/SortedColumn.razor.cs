namespace Memorabilia.Blazor.Controls.Grids;

public partial class SortedColumn<TItem>
{
    [Parameter]
    public Func<TItem, object> SortBy { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
