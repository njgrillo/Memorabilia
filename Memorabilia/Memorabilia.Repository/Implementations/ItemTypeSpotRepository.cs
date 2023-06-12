namespace Memorabilia.Repository.Implementations;

public class ItemTypeSpotRepository 
    : DomainRepository<Entity.ItemTypeSpot>, IItemTypeSpotRepository
{
    public ItemTypeSpotRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<Entity.ItemTypeSpot[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue
            ? await Items.ToArrayAsync()
            : await Items.Where(itemTypeSpot => itemTypeSpot.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}
