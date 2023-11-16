namespace Memorabilia.Repository.Implementations;

public class PrivateSigningRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<PrivateSigning>(context, memoryCache), IPrivateSigningRepository
{
    public async Task<PagedResult<PrivateSigning>> GetAll(PageInfo pageInfo, int? userId = null)
    {
        var query =
            from privateSigning in Context.PrivateSigning
            where userId == null || privateSigning.CreatedUserId == userId
            orderby privateSigning.CreatedDate descending
            select new PrivateSigning(privateSigning);

        return await query.ToPagedResult(pageInfo);
    }
}
