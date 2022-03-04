using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IPersonRepository
    {
        Task Add(Entities.Person person, CancellationToken cancellationToken = default);

        Task Delete(Entities.Person person, CancellationToken cancellationToken = default);

        Task<Entities.Person> Get(int id);

        Task<IEnumerable<Entities.Person>> GetAll(int? sportId = null);

        Task Update(Entities.Person person, CancellationToken cancellationToken = default);
    }
}
