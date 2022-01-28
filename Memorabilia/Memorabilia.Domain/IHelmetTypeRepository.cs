using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IHelmetTypeRepository
    {
        Task Add(Entities.HelmetType helmetType, CancellationToken cancellationToken = default);

        Task Delete(Entities.HelmetType helmetType, CancellationToken cancellationToken = default);

        Task<Entities.HelmetType> Get(int id);

        Task<IEnumerable<Entities.HelmetType>> GetAll();

        Task Update(Entities.HelmetType helmetType, CancellationToken cancellationToken = default);
    }
}
