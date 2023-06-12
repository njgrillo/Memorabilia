namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class ViewMemorabilia
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected bool IsDetailView = true;

    protected MemorabiliasModel Model = new();

    private MemorabiliaSearchCriteria _filter = new();

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
    }
}
