namespace Memorabilia.Repository.Implementations;

public class CollectionRepository 
    : MemorabiliaRepository<Entity.Collection>, ICollectionRepository
{
    public CollectionRepository(MemorabiliaContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.Collection> Collections 
        => Items.Include(collection => collection.Memorabilia);

    public override async Task<Entity.Collection> Get(int id)
        => await Collections.SingleOrDefaultAsync(collection => collection.Id == id);

    public async Task<Entity.Collection[]> GetAll(int userId)
        => await Collections.Where(collection => collection.UserId == userId)
                            .ToArrayAsync();
}
