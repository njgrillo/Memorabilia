namespace Memorabilia.Repository.Implementations;

public class AutographImageRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<AutographImage>(context, memoryCache), IAutographImageRepository
{
    public async Task<AutographImage[]> GetAll(int autographId)
        => await Items.Where(autographImage => autographImage.AutographId == autographId)
                      .OrderBy(autographImage => autographImage.ImageTypeId)
                      .ToArrayAsync();
}
