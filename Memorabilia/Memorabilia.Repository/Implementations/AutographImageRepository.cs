using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class AutographImageRepository : MemorabiliaRepository<AutographImage>, IAutographImageRepository
{
    public AutographImageRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    public async Task<List<AutographImage>> GetAll(int autographId)
    {
        return await Items.Where(image => image.AutographId == autographId).ToListAsync();
    }
}
