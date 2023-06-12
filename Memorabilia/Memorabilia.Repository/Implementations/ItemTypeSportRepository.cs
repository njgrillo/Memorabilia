namespace Memorabilia.Repository.Implementations;

public class ItemTypeSportRepository 
    : DomainRepository<Entity.ItemTypeSport>, IItemTypeSportRepository
{
    public ItemTypeSportRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    public async Task<Entity.ItemTypeSport[]> GetAll(int? itemTypeId = null)
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
