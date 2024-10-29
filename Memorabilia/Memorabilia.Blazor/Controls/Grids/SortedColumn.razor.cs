namespace Memorabilia.Blazor.Controls.Grids;

public partial class SortedColumn<TItem>
{
    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public Func<TItem, object> SortBy { get; set; }
}
