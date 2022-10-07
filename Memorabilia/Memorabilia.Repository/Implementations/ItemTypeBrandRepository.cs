using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ItemTypeBrandRepository : DomainRepository<ItemTypeBrand>, IItemTypeBrandRepository
{
    public ItemTypeBrandRepository(DomainContext context) : base(context) { }

    public async Task<IEnumerable<ItemTypeBrand>> GetAll(int? itemTypeId = null)
    {
        return !itemTypeId.HasValue
            ? await Items.ToListAsync()
            : await Items.Where(itemTypeBrand => itemTypeBrand.ItemTypeId == itemTypeId).ToListAsync();
    }
}
