namespace Memorabilia.Repository.Implementations;

public class PrivateSigningRepository
    : MemorabiliaRepository<Entity.PrivateSigning>, IPrivateSigningRepository
{
    public PrivateSigningRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<PagedResult<Entity.PrivateSigning>> GetAll(PageInfo pageInfo, int? userId = null)
    {
        var query =
            from privateSigning in Context.PrivateSigning
            where userId == null || privateSigning.CreatedUserId == userId
            orderby privateSigning.CreatedDate descending
            select new Entity.PrivateSigning(privateSigning);

        return await query.ToPagedResult(pageInfo);
    }
}
