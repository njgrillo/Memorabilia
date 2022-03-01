using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IHelmetFinishRepository
    {
        Task Add(Entities.HelmetFinish helmetFinish, CancellationToken cancellationToken = default);

        Task Delete(Entities.HelmetFinish helmetFinish, CancellationToken cancellationToken = default);

        Task<Entities.HelmetFinish> Get(int id);

        Task<IEnumerable<Entities.HelmetFinish>> GetAll();

        Task Update(Entities.HelmetFinish helmetFinish, CancellationToken cancellationToken = default);
    }
}
