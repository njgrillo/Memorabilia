using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IItemTypeRepository
    {
        Task Add(ItemType itemType, CancellationToken cancellationToken = default);

        Task Delete(ItemType itemType, CancellationToken cancellationToken = default);

        Task<ItemType> Get(int id);

        Task<IEnumerable<ItemType>> GetAll();

        Task Update(ItemType itemType, CancellationToken cancellationToken = default);
    }
}
