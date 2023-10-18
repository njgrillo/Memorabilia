namespace Memorabilia.Repository.Implementations;

public class ItemTypeSizeRepository 
    : DomainRepository<ItemTypeSize>, IItemTypeSizeRepository
{
    public ItemTypeSizeRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<ItemTypeSize[]> GetAll(int? itemTypeId = null) 
        => !itemTypeId.HasValue 
            ? await Items.ToArrayAsync() 
            : await Items.Where(itemTypeSize => itemTypeSize.ItemTypeId == itemTypeId)
                         .ToArrayAsync();
}