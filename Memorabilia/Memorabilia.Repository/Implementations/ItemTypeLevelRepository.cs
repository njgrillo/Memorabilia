using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ItemTypeLevelRepository : DomainRepository<ItemTypeLevel>, IItemTypeLevelRepository
{
    public ItemTypeLevelRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    public async Task<IEnumerable<ItemTypeLevel>> GetAll(int? itemTypeId = null)
    {
        return !itemTypeId.HasValue
            ? await Items.ToListAsync()
            : await Items.Where(itemTypeLevelType => itemTypeLevelType.ItemTypeId == itemTypeId).ToListAsync();
    }
}
