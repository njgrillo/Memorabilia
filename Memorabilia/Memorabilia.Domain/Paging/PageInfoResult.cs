namespace Memorabilia.Domain.Paging;

public class PageInfoResult : PageInfo, IPageInfoResult
{
    public int PageCount
        => (int)Math.Ceiling(TotalItems / (double)PageSize);

    public int TotalItems { get; init; }
}
