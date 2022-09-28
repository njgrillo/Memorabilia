using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user, CancellationToken cancellationToken = default);

        Task Delete(User user, CancellationToken cancellationToken = default);

        Task<User> Get(int id);

        Task<User> Get(string username, string password);

        Task Update(User user, CancellationToken cancellationToken = default);
    }
}
