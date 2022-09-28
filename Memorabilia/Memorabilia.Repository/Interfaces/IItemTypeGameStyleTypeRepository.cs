using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IItemTypeGameStyleTypeRepository
    {
        Task Add(ItemTypeGameStyleType itemTypeGameStyleType, CancellationToken cancellationToken = default);

        Task Delete(ItemTypeGameStyleType itemTypeGameStyleType, CancellationToken cancellationToken = default);

        Task<ItemTypeGameStyleType> Get(int id);

        Task<IEnumerable<ItemTypeGameStyleType>> GetAll(int? itemTypeId = null);

        Task Update(ItemTypeGameStyleType itemTypeGameStyleType, CancellationToken cancellationToken = default);
    }
}
