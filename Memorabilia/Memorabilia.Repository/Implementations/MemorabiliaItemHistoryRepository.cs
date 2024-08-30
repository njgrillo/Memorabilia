namespace Memorabilia.Repository.Implementations;

public class MemorabiliaItemHistoryRepository(HistoryContext context)
    : HistoryRepository<MemorabiliaHistory>(context), IMemorabiliaItemHistoryRepository
{
    public async Task<MemorabiliaHistory[]> GetAll(int userId)
    {
        var query =
            from memorabiliaHistory in Context.MemorabiliaHistories
            where memorabiliaHistory.UserId == userId
            select new MemorabiliaHistory(memorabiliaHistory);

        return await query.ToArrayAsync();
    }

    public async Task<MemorabiliaHistory[]> GetAll(int[] ids)
    {
        MemorabiliaHistory[] items 
            = await Items.Where(memorabilia => ids.Contains(memorabilia.Id)).ToArrayAsync();

        return items;
    }

    public async Task<PagedResult<MemorabiliaHistory>> GetAll(int userId, PageInfo pageInfo)
    {
        var query =
            from memorabiliaHistory in Context.MemorabiliaHistories
            where memorabiliaHistory.UserId == userId
            orderby memorabiliaHistory.CreateDate descending
            select new MemorabiliaHistory(memorabiliaHistory);

        return await query.ToPagedResult(pageInfo);
    }
}
