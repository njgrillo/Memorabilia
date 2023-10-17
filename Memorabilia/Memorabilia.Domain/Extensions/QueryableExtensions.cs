namespace Memorabilia.Domain.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedResult<T>> ToPagedResult<T>(this IQueryable<T> query, PageInfo queryPageInfo)
        where T : class
    {
        var totalItems = query.Count();

        var result = new PagedResult<T>(
            Data : query.Skip(queryPageInfo.Skip)
                        .Take(queryPageInfo.PageSize)
                        .ToArray(),
            PageInfo: new PageInfoResult
            {
                PageNumber = queryPageInfo.PageNumber,
                PageSize = queryPageInfo.PageSize,
                TotalItems = totalItems
            });

        return await Task.FromResult(result);
    }
}
