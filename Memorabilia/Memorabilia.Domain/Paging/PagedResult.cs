namespace Memorabilia.Domain.Paging;

public record PagedResult<TData>(PageInfoResult PageInfo, TData[] Data)
{
	public PagedResult() : this(new PageInfoResult(), []) { }
}
