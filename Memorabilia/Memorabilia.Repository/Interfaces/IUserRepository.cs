namespace Memorabilia.Repository.Interfaces;

public interface IUserRepository : IDomainRepository<Entity.User>
{
    Task<Entity.User> Get(string emailAddress);

    Task<Entity.User> GetByUsername(string username);
}
