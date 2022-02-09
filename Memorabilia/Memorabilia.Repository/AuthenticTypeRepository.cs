using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class AuthenticTypeRepository : BaseRepository<Domain.Entities.AuthenticType>, IAuthenticTypeRepository
    {
        private readonly Context _context;

        public AuthenticTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.AuthenticType> AuthenticType => _context.Set<Domain.Entities.AuthenticType>();

        public async Task Add(Domain.Entities.AuthenticType authenticType, CancellationToken cancellationToken = default)
        {
            _context.Add(authenticType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.AuthenticType authenticType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.AuthenticType>().Remove(authenticType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.AuthenticType> Get(int id)
        {
            return await AuthenticType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.AuthenticType>> GetAll()
        {
            return await AuthenticType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.AuthenticType authenticType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.AuthenticType>().Update(authenticType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
