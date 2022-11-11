using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ItemTypeSizeRepository : DomainRepository<ItemTypeSize>, IItemTypeSizeRepository
{
    public ItemTypeSizeRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    public async Task<IEnumerable<ItemTypeSize>> GetAll(int? itemTypeId = null)
    {
        return !itemTypeId.HasValue
            ? await Items.ToListAsync()
            : await Items.Where(itemTypeSize => itemTypeSize.ItemTypeId == itemTypeId).ToListAsync();
    }
}