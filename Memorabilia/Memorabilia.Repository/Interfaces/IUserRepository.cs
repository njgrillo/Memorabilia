using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IUserRepository : IDomainRepository<User>
{
    Task<User> Get(string username, string password);
}
