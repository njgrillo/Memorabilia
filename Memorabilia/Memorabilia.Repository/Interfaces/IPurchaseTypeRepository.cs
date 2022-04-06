using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPurchaseTypeRepository
    {
        Task Add(PurchaseType purchaseType, CancellationToken cancellationToken = default);

        Task Delete(PurchaseType purchaseType, CancellationToken cancellationToken = default);

        Task<PurchaseType> Get(int id);

        Task<IEnumerable<PurchaseType>> GetAll();

        Task Update(PurchaseType purchaseType, CancellationToken cancellationToken = default);
    }
}
