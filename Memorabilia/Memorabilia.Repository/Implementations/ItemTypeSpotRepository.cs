namespace Memorabilia.Repository.Implementations;

public class ItemTypeSpotRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ItemTypeSpot>(context, memoryCache), IItemTypeSpotRepository
{
    public async Task<ItemTypeSpot[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue
            ? await Items.ToArrayAsync()
            : await Items.Where(itemTypeSpot => itemTypeSpot.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}
