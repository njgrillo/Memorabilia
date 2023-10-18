namespace Memorabilia.Repository.Implementations;

public class ItemTypeBrandRepository 
    : DomainRepository<ItemTypeBrand>, IItemTypeBrandRepository
{
    public ItemTypeBrandRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<ItemTypeBrand[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue
            ? await Items.ToArrayAsync()
            : await Items.Where(itemTypeBrand => itemTypeBrand.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}
