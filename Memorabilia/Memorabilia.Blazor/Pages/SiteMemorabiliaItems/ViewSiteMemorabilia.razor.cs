namespace Memorabilia.Blazor.Pages.SiteMemorabiliaItems;

public partial class ViewSiteMemorabilia
{
    protected bool IsDetailView
        = true;

    private MemorabiliaSearchCriteria _filter
        = new();

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
    }
}
