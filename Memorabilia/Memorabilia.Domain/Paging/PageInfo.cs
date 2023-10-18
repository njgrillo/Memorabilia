namespace Memorabilia.Domain.Paging;

public class PageInfo : IPageInfo
{
    public PageInfo() { }

    public PageInfo(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public static PageInfo Default
        => new(1, 100);

    public static PageInfo Max
        => new(1, int.MaxValue);

    public int PageNumber { get; set; }
        = 1;

    public int PageSize { get; set; }
        = 10;

    public int Skip
        => PageSize * (PageNumber - 1);
}
