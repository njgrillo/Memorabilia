namespace Memorabilia.Domain.Paging;

public interface IPageInfoResult
{
    int PageCount { get; }

    int TotalItems { get; init; }
}
