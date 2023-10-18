namespace Memorabilia.Repository.Implementations;

public class MemorabiliaImageRepository 
    : MemorabiliaRepository<MemorabiliaImage>, IMemorabiliaImageRepository
{
    public MemorabiliaImageRepository(MemorabiliaContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<MemorabiliaImage[]> GetAll(int memorabiliaId)
        => await Items.Where(memorabiliaImage => memorabiliaImage.MemorabiliaId == memorabiliaId)
                      .OrderBy(memorabiliaImage => memorabiliaImage.ImageTypeId)
                      .ToArrayAsync();
}
