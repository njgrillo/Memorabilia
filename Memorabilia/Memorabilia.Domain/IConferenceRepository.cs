using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IConferenceRepository
    {
        Task Add(Entities.Conference conference, CancellationToken cancellationToken = default);

        Task Delete(Entities.Conference conference, CancellationToken cancellationToken = default);

        Task<Entities.Conference> Get(int id);

        Task<IEnumerable<Entities.Conference>> GetAll();

        Task Update(Entities.Conference conference, CancellationToken cancellationToken = default);
    }
}
