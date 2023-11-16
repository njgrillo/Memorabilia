namespace Memorabilia.Repository.Implementations;

public class CollectionRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<Collection>(context, memoryCache), ICollectionRepository
{
    private IQueryable<Collection> Collections 
        => Items.Include(collection => collection.Memorabilia);

    public override async Task<Collection> Get(int id)
        => await Collections.SingleOrDefaultAsync(collection => collection.Id == id);

    public async Task<Collection[]> GetAll(int userId)
        => await Collections.Where(collection => collection.UserId == userId)
                            .ToArrayAsync();
}
