namespace Memorabilia.Repository.Implementations;

public class ItemTypeGameStyleTypeRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ItemTypeGameStyleType>(context, memoryCache), IItemTypeGameStyleTypeRepository
{
    public async Task<ItemTypeGameStyleType[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue 
           ? await Items.ToArrayAsync() 
           : await Items.Where(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeId == itemTypeId)
                        .ToArrayAsync();
}
