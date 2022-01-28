using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IGloveTypeRepository
    {
        Task Add(Entities.GloveType gloveType, CancellationToken cancellationToken = default);

        Task Delete(Entities.GloveType gloveType, CancellationToken cancellationToken = default);

        Task<Entities.GloveType> Get(int id);

        Task<IEnumerable<Entities.GloveType>> GetAll();

        Task Update(Entities.GloveType gloveType, CancellationToken cancellationToken = default);
    }
}
