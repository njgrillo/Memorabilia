using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task Add(Person person, CancellationToken cancellationToken = default);

        Task Delete(Person person, CancellationToken cancellationToken = default);

        Task<Person> Get(int id);

        Task<IEnumerable<Person>> GetAll(int? sportId = null);

        Task Update(Person person, CancellationToken cancellationToken = default);
    }
}
