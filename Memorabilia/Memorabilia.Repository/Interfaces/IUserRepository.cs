namespace Memorabilia.Repository.Interfaces;

public interface IUserRepository : IDomainRepository<Entity.User>
{
    Task<Entity.User> Get(string emailAddress);

    Task<Entity.User> GetByGoogleEmailAddress(string emailAddress);

    Task<Entity.User> GetByMicrosoftEmailAddress(string emailAddress);

    Task<Entity.User> GetByUsername(string username);

    Task<Entity.User> GetByXHandle(string handle);
}
