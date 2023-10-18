namespace Memorabilia.Repository.Interfaces;

public interface IUserRepository : IDomainRepository<User>
{
    Task<User> Get(string emailAddress);

    Task<User[]> GetAllByActiveSubscriptions();

    Task<User[]> GetAllBySubscriptionExpired();

    Task<User> GetByGoogleEmailAddress(string emailAddress);

    Task<User> GetByMicrosoftEmailAddress(string emailAddress);

    Task<User> GetByUsername(string username);

    Task<User> GetByXHandle(string handle);
}
