namespace Memorabilia.Repository.Implementations;

public class MemorabiliaImageRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<MemorabiliaImage>(context, memoryCache), IMemorabiliaImageRepository
{
    public async Task<MemorabiliaImage[]> GetAll(int memorabiliaId)
        => await Items.Where(memorabiliaImage => memorabiliaImage.MemorabiliaId == memorabiliaId)
                      .OrderBy(memorabiliaImage => memorabiliaImage.ImageTypeId)
                      .ToArrayAsync();
}
