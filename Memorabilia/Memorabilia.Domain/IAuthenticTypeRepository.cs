using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IAuthenticTypeRepository
    {
        Task Add(Entities.AuthenticType authenticType, CancellationToken cancellationToken = default);

        Task Delete(Entities.AuthenticType authenticType, CancellationToken cancellationToken = default);

        Task<Entities.AuthenticType> Get(int id);

        Task<IEnumerable<Entities.AuthenticType>> GetAll();

        Task Update(Entities.AuthenticType authenticType, CancellationToken cancellationToken = default);
    }
}
