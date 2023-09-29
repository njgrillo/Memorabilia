namespace Memorabilia.Repository.Implementations;

public class PrivateSigningRepository
    : MemorabiliaRepository<Entity.PrivateSigning>, IPrivateSigningRepository
{
    public PrivateSigningRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<PagedResult<Entity.PrivateSigning>> GetAll(PageInfo pageInfo)
    {
        var query =
            from privateSigning in Context.PrivateSigning
            orderby privateSigning.CreatedDate descending
            select new Entity.PrivateSigning(privateSigning);

        return await query.ToPagedResult(pageInfo);
    }
}
