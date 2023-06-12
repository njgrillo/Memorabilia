namespace Memorabilia.Repository.Implementations;

public class UserRepository 
    : DomainRepository<Entity.User>, IUserRepository
{
    public UserRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.User> User 
        => Items.Include(user => user.DashboardItems);

    public override async Task<Entity.User> Get(int id)
        => await User.SingleOrDefaultAsync(user => user.Id == id);

    public async Task<Entity.User> Get(string username, string password)
        => await User.SingleOrDefaultAsync(user => user.Username == username && user.Password == password);
}
