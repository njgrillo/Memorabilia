using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IPersonOccupationRepository
    {
        Task Add(Entities.PersonOccupation personOccupation, CancellationToken cancellationToken = default);

        Task Delete(Entities.PersonOccupation personOccupation, CancellationToken cancellationToken = default);

        Task<Entities.PersonOccupation> Get(int id);

        Task<IEnumerable<Entities.PersonOccupation>> GetAll(int? personId = null);

        Task Update(Entities.PersonOccupation personOccupation, CancellationToken cancellationToken = default);
    }
}
