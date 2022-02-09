using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IItemTypeAuthenticTypeRepository
    {
        Task Add(ItemTypeAuthenticType itemTypeAuthenticType, CancellationToken cancellationToken = default);

        Task Delete(ItemTypeAuthenticType itemTypeAuthenticType, CancellationToken cancellationToken = default);

        Task<ItemTypeAuthenticType> Get(int id);

        Task<IEnumerable<ItemTypeAuthenticType>> GetAll(int? itemTypeId = null);

        Task Update(ItemTypeAuthenticType itemTypeAuthenticType, CancellationToken cancellationToken = default);
    }
}
