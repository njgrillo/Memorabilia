using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IBasketballTypeRepository
    {
        Task Add(Entities.BasketballType basketballType, CancellationToken cancellationToken = default);

        Task Delete(Entities.BasketballType basketballType, CancellationToken cancellationToken = default);

        Task<Entities.BasketballType> Get(int id);

        Task<IEnumerable<Entities.BasketballType>> GetAll();

        Task Update(Entities.BasketballType basketballType, CancellationToken cancellationToken = default);
    }
}
