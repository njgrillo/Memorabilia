using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DomainContext _context;

        public UserRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<User> User => _context.Set<User>().Include(user => user.DashboardItems);

        public async Task Add(User user, CancellationToken cancellationToken = default)
        {
            _context.Add(user);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(User user, CancellationToken cancellationToken = default)
        {
            _context.Set<User>().Remove(user);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<User> Get(int id)
        {
            return await User.SingleOrDefaultAsync(user => user.Id == id)
                               .ConfigureAwait(false);
        }

        public async Task<User> Get(string username, string password)
        {
            return await User.SingleOrDefaultAsync(user => user.Username == username && user.Password == password)
                               .ConfigureAwait(false);
        }

        public async Task Update(User user, CancellationToken cancellationToken = default)
        {
            _context.Set<User>().Update(user);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
