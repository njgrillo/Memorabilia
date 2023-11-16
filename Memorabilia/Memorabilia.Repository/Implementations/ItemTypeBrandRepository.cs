namespace Memorabilia.Repository.Implementations;

public class ItemTypeBrandRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ItemTypeBrand>(context, memoryCache), IItemTypeBrandRepository
{
    public async Task<ItemTypeBrand[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue
            ? await Items.ToArrayAsync()
            : await Items.Where(itemTypeBrand => itemTypeBrand.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}
