namespace Memorabilia.Repository.Implementations;

public class ItemTypeSportRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ItemTypeSport>(context, memoryCache), IItemTypeSportRepository
{
    public async Task<ItemTypeSport[]> GetAll(int? itemTypeId = null)
        => !itemTypeId.HasValue
            ? (await Items.ToArrayAsync())
                .OrderBy(itemTypeSport => itemTypeSport.ItemTypeName)
                .ThenBy(itemTypeSport => itemTypeSport.SportName)
                .ToArray()
            : (await Items.Where(itemTypeSport => itemTypeSport.ItemTypeId == itemTypeId)
                          .ToArrayAsync())
                .OrderBy(itemTypeSport => itemTypeSport.ItemTypeName)
                .ThenBy(itemTypeSport => itemTypeSport.SportName)
                .ToArray();
}
