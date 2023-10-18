namespace Memorabilia.Repository.Implementations;

public class AutographImageRepository 
    : MemorabiliaRepository<AutographImage>, IAutographImageRepository
{
    public AutographImageRepository(MemorabiliaContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<AutographImage[]> GetAll(int autographId)
        => await Items.Where(autographImage => autographImage.AutographId == autographId)
                      .OrderBy(autographImage => autographImage.ImageTypeId)
                      .ToArrayAsync();
}
