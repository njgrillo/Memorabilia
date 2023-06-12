namespace Memorabilia.Repository.Implementations;

public class ItemTypeGameStyleTypeRepository 
    : DomainRepository<Entity.ItemTypeGameStyleType>, IItemTypeGameStyleTypeRepository
{
    public ItemTypeGameStyleTypeRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<Entity.ItemTypeGameStyleType[]> GetAll(int? itemTypeId = null)
    => !itemTypeId.HasValue 
        ? await Items.ToArrayAsync() 
        : await Items.Where(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeId == itemTypeId)
                     .ToArrayAsync();
}
