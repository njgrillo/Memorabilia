namespace Memorabilia.Repository.Interfaces;

public interface IUserRepository : IDomainRepository<Entity.User>
{
    Task<Entity.User> Get(string username, string password);
}
