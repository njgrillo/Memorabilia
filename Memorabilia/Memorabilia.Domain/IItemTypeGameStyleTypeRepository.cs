using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
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
