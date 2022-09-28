using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IItemTypeLevelRepository
    {
        Task Add(ItemTypeLevel itemTypeLevel, CancellationToken cancellationToken = default);

        Task Delete(ItemTypeLevel itemTypeLevel, CancellationToken cancellationToken = default);

        Task<ItemTypeLevel> Get(int id);

        Task<IEnumerable<ItemTypeLevel>> GetAll(int? itemTypeId = null);

        Task Update(ItemTypeLevel itemTypeLevel, CancellationToken cancellationToken = default);
    }
}
