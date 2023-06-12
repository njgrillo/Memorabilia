namespace Memorabilia.Repository.Implementations;

public class ItemTypeBrandRepository 
    : DomainRepository<Entity.ItemTypeBrand>, IItemTypeBrandRepository
{
    public ItemTypeBrandRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<Entity.ItemTypeBrand[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue
            ? await Items.ToArrayAsync()
            : await Items.Where(itemTypeBrand => itemTypeBrand.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}
