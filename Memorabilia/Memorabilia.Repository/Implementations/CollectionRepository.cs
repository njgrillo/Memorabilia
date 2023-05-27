using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class CollectionRepository : MemorabiliaRepository<Collection>, ICollectionRepository
{
    public CollectionRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Collection> Collections => Items.Include(collection => collection.Memorabilia);

    public override async Task<Collection> Get(int id)
    {
        return await Collections.SingleOrDefaultAsync(collection => collection.Id == id);
    }

    public async Task<IEnumerable<Collection>> GetAll(int userId)
    {
        return await Collections.Where(collection => collection.UserId == userId)
                                .ToListAsync();
    }
}
