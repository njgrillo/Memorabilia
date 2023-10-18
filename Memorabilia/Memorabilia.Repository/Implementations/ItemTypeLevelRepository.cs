namespace Memorabilia.Repository.Implementations;

public class ItemTypeLevelRepository 
    : DomainRepository<ItemTypeLevel>, IItemTypeLevelRepository
{
    public ItemTypeLevelRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<ItemTypeLevel[]> GetAll(int? itemTypeId = null)
    => !itemTypeId.HasValue 
        ? await Items.ToArrayAsync() 
        : await Items.Where(itemTypeLevelType => itemTypeLevelType.ItemTypeId == itemTypeId)
                     .ToArrayAsync();
}
