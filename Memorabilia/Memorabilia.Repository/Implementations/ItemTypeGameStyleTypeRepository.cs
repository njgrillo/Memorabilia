using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ItemTypeGameStyleTypeRepository : DomainRepository<ItemTypeGameStyleType>, IItemTypeGameStyleTypeRepository
{
    public ItemTypeGameStyleTypeRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    public async Task<IEnumerable<ItemTypeGameStyleType>> GetAll(int? itemTypeId = null)
    {
        return !itemTypeId.HasValue
            ? await Items.ToListAsync()
            : await Items.Where(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeId == itemTypeId).ToListAsync();
    }
}
