namespace Memorabilia.Repository.Implementations;

public class UserRepository 
    : DomainRepository<User>, IUserRepository
{
    public UserRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<User> User 
        => Items.Include(user => user.BookmarkedForumTopics)
                .Include(user => user.DashboardItems)
                .Include(user => user.Roles)
                //.Include(user => user.Roles.Select(userRole => userRole.Role))
                .Include(user => user.UserSettings);

    public override async Task<User> Get(int id)
        => await User.SingleOrDefaultAsync(user => user.Id == id);

    public async Task<User> Get(string emailAddress)
        => await User.SingleOrDefaultAsync(user => user.EmailAddress == emailAddress);

    public async Task<User[]> GetAllByActiveSubscriptions()
        => await User.Where(user => !user.SubscriptionExpirationDate.HasValue 
                                 && user.StripeSubscriptionId != null)
                     .ToArrayAsync();

    public async Task<User[]> GetAllBySubscriptionExpired()
        => await User.Where(user => user.SubscriptionExpirationDate.HasValue 
                                 && user.SubscriptionExpirationDate < DateTime.UtcNow)
                     .ToArrayAsync();

    public async Task<User> GetByGoogleEmailAddress(string emailAddress)
        => await User.SingleOrDefaultAsync(user => user.UserSettings != null 
                                                && user.UserSettings.GoogleEmailAddress == emailAddress);

    public async Task<User> GetByMicrosoftEmailAddress(string emailAddress)
        => await User.SingleOrDefaultAsync(user => user.UserSettings != null
                                                && user.UserSettings.MicrosoftEmailAddress == emailAddress);

    public async Task<User> GetByUsername(string username)
        => await User.SingleOrDefaultAsync(user => user.Username == username);

    public async Task<User> GetByXHandle(string handle)
        => await User.SingleOrDefaultAsync(user => user.UserSettings != null
                                                && user.UserSettings.XHandle == handle);
}
