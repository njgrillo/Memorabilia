namespace Memorabilia.Repository.Implementations;

public class ItemTypeSizeRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ItemTypeSize>(context, memoryCache), IItemTypeSizeRepository
{
    public async Task<ItemTypeSize[]> GetAll(int? itemTypeId = null) 
        => !itemTypeId.HasValue 
            ? await Items.ToArrayAsync() 
            : await Items.Where(itemTypeSize => itemTypeSize.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}