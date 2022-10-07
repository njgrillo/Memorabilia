using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class UserRepository : DomainRepository<User>, IUserRepository
{
    public UserRepository(DomainContext context) : base(context) { }

    private IQueryable<User> User => Items.Include(user => user.DashboardItems);

    public override async Task<User> Get(int id)
    {
        return await User.SingleOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User> Get(string username, string password)
    {
        return await User.SingleOrDefaultAsync(user => user.Username == username && user.Password == password);
    }
}
