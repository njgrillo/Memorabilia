namespace Memorabilia.Repository.Implementations;

public class PrivateSigningCustomItemGroupRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<PrivateSigningCustomItemGroup>(context, memoryCache), IPrivateSigningCustomItemGroupRepository
{
    public async Task<PrivateSigningCustomItemGroup[]> GetAll(int userId)
        => await Items.Where(group => group.CreatedByUserId == userId)
                      .ToArrayAsync();
}
