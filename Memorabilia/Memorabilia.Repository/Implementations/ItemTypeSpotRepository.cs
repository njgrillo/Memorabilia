using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ItemTypeSpotRepository : DomainRepository<ItemTypeSpot>, IItemTypeSpotRepository
{
    public ItemTypeSpotRepository(DomainContext context) : base(context) { }

    public async Task<IEnumerable<ItemTypeSpot>> GetAll(int? itemTypeId = null)
    {
        return !itemTypeId.HasValue
            ? await Items.ToListAsync()
            : await Items.Where(itemTypeSpot => itemTypeSpot.ItemTypeId == itemTypeId).ToListAsync();
    }
}
