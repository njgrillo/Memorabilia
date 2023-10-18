namespace Memorabilia.Repository.Implementations;

public class ItemTypeGameStyleTypeRepository 
    : DomainRepository<ItemTypeGameStyleType>, IItemTypeGameStyleTypeRepository
{
    public ItemTypeGameStyleTypeRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<ItemTypeGameStyleType[]> GetAll(int? itemTypeId = null)
    => !itemTypeId.HasValue 
        ? await Items.ToArrayAsync() 
        : await Items.Where(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeId == itemTypeId)
                     .ToArrayAsync();
}
