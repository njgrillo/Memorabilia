using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface ITeamDivisionRepository
    {
        Task Add(Entities.TeamDivision teamDivision, CancellationToken cancellationToken = default);

        Task Delete(Entities.TeamDivision teamDivision, CancellationToken cancellationToken = default);

        Task<Entities.TeamDivision> Get(int id);

        Task<IEnumerable<Entities.TeamDivision>> GetAll(int? teamId = null);

        Task Update(Entities.TeamDivision teamDivision, CancellationToken cancellationToken = default);
    }
}
