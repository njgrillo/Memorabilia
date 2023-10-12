namespace Memorabilia.Repository.Implementations;

public class PrivateSigningCustomItemTypeGroupRepository
    : MemorabiliaRepository<Entity.PrivateSigningCustomItemTypeGroup>, IPrivateSigningCustomItemTypeGroupRepository
{
    public PrivateSigningCustomItemTypeGroupRepository(MemorabiliaContext context, IMemoryCache memoryCache)
       : base(context, memoryCache) { }

    public async Task<Entity.PrivateSigningCustomItemTypeGroup[]> GetAll(int userId)
        => await Items.Where(group => group.PrivateSigningCustomItemGroup.CreatedByUserId == userId)
                      .ToArrayAsync();
}
