namespace Memorabilia.Repository.Implementations;

public class ItemTypeLevelRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ItemTypeLevel>(context, memoryCache), IItemTypeLevelRepository
{
    public async Task<ItemTypeLevel[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue 
            ? await Items.ToArrayAsync() 
            : await Items.Where(itemTypeLevelType => itemTypeLevelType.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}
