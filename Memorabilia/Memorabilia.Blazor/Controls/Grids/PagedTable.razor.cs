namespace Memorabilia.Blazor.Controls.Grids;

public partial class PagedTable<TItem> where TItem : class
{
    [Parameter]
    public bool Bordered { get; set; }

    [Parameter]
    public RenderFragment Columns { get; set; }

    [Parameter]
    public bool Dense { get; set; }

    [Parameter]
    public bool Hover { get; set; }
        = true;

    [Parameter]
    public List<TItem> Items { get; set; }
        = [];

    [Parameter]
    public Func<TableState, Task<TableData<TItem>>> OnRead { get; set; }

    [Parameter]
    public RenderFragment Rows { get; set; }

    [Parameter]
    public bool Striped { get; set; }
        = true;

    [Parameter]
    public string Title { get; set; }
        = "Records";

    [Parameter]
    public bool Virtualize { get; set; }
        = true;

    protected string Search { get; private set; }

    private MudTable<TItem> _table = new();

    protected virtual void Filter(string search)
    {
        Search = search;

        _table.ReloadServerData();
    }
}
