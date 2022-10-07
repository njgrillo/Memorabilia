using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class MemorabiliaImageRepository : MemorabiliaRepository<MemorabiliaImage>, IMemorabiliaImageRepository
{
    public MemorabiliaImageRepository(MemorabiliaContext context) : base(context) { }

    public async Task<List<MemorabiliaImage>> GetAll(int memorabiliaId)
    {
        return await Items.Where(memorabiliaImage => memorabiliaImage.MemorabiliaId == memorabiliaId).ToListAsync();
    }
}
