using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Domain
{
    public interface IUserRepository
    {
        Task Add(Entities.User user, CancellationToken cancellationToken = default);

        Task Delete(Entities.User user, CancellationToken cancellationToken = default);

        Task<Entities.User> Get(int id);

        Task<Entities.User> Get(string username, string password);

        Task Update(Entities.User user, CancellationToken cancellationToken = default);
    }
}
