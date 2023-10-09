namespace Memorabilia.Repository.Implementations;

public class PrivateSigningCustomItemGroupRepository
    : MemorabiliaRepository<Entity.PrivateSigningCustomItemGroup>, IPrivateSigningCustomItemGroupRepository
{
    public PrivateSigningCustomItemGroupRepository(MemorabiliaContext context, IMemoryCache memoryCache)
       : base(context, memoryCache) { }

    public async Task<Entity.PrivateSigningCustomItemGroup[]> GetAll(int userId)
        => await Items.Where(group => group.CreatedByUserId == userId)
                      .ToArrayAsync();
}
