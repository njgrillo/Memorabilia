using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class UserRepository : BaseRepository<Domain.Entities.User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.User> User => _context.Set<Domain.Entities.User>();

        public async Task Add(Domain.Entities.User user, CancellationToken cancellationToken = default)
        {
            _context.Add(user);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.User user, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.User>().Remove(user);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.User> Get(int id)
        {
            return await User.SingleOrDefaultAsync(user => user.Id == id)
                               .ConfigureAwait(false);
        }

        public async Task<Domain.Entities.User> Get(string username, string password)
        {
            return await User.SingleOrDefaultAsync(user => user.Username == username && user.Password == password)
                               .ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.User user, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.User>().Update(user);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
