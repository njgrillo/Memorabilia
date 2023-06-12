namespace Memorabilia.Repository.Implementations;

public class AutographImageRepository 
    : MemorabiliaRepository<Entity.AutographImage>, IAutographImageRepository
{
    public AutographImageRepository(MemorabiliaContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<Entity.AutographImage[]> GetAll(int autographId)
        => await Items.Where(image => image.AutographId == autographId)
                      .ToArrayAsync();
}
