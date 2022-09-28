using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IItemTypeSpotRepository
    {
        Task Add(ItemTypeSpot itemTypeSpot, CancellationToken cancellationToken = default);

        Task Delete(ItemTypeSpot itemTypeSpot, CancellationToken cancellationToken = default);

        Task<ItemTypeSpot> Get(int id);

        Task<IEnumerable<ItemTypeSpot>> GetAll(int? itemTypeId = null);

        Task Update(ItemTypeSpot itemTypeSpot, CancellationToken cancellationToken = default);
    }
}
