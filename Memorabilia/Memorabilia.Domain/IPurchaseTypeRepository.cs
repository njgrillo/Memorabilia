using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IPurchaseTypeRepository
    {
        Task Add(Entities.PurchaseType purchaseType, CancellationToken cancellationToken = default);

        Task Delete(Entities.PurchaseType purchaseType, CancellationToken cancellationToken = default);

        Task<Entities.PurchaseType> Get(int id);

        Task<IEnumerable<Entities.PurchaseType>> GetAll();

        Task Update(Entities.PurchaseType purchaseType, CancellationToken cancellationToken = default);
    }
}
