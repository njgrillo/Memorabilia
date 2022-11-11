using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ItemTypeSportRepository : DomainRepository<ItemTypeSport>, IItemTypeSportRepository
{
    public ItemTypeSportRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    public async Task<IEnumerable<ItemTypeSport>> GetAll(int? itemTypeId = null)
    {
        return !itemTypeId.HasValue
            ? (await Items.ToListAsync()).OrderBy(itemTypeSport => itemTypeSport.ItemTypeName)
                                                 .ThenBy(itemTypeSport => itemTypeSport.SportName)
            : (await Items.Where(itemTypeSport => itemTypeSport.ItemTypeId == itemTypeId)
                                  .ToListAsync()).OrderBy(itemTypeSport => itemTypeSport.ItemTypeName)
                                                 .ThenBy(itemTypeSport => itemTypeSport.SportName);
    }
}
