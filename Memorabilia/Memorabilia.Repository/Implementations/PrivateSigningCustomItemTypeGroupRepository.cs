namespace Memorabilia.Repository.Implementations;

public class PrivateSigningCustomItemTypeGroupRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<PrivateSigningCustomItemTypeGroup>(context, memoryCache), IPrivateSigningCustomItemTypeGroupRepository
{
    public async Task<PrivateSigningCustomItemTypeGroup[]> GetAll(int userId)
        => await Items.Where(group => group.PrivateSigningCustomItemGroup.CreatedByUserId == userId)
                      .ToArrayAsync();
}
