using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonOccupationRepository
    {
        Task Add(PersonOccupation personOccupation, CancellationToken cancellationToken = default);

        Task Delete(PersonOccupation personOccupation, CancellationToken cancellationToken = default);

        Task<PersonOccupation> Get(int id);

        Task<IEnumerable<PersonOccupation>> GetAll(int? personId = null);

        Task Update(PersonOccupation personOccupation, CancellationToken cancellationToken = default);
    }
}
