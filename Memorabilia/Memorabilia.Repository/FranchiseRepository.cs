using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FranchiseRepository : BaseRepository<Domain.Entities.Franchise>, IFranchiseRepository
    {
        private readonly Context _context;

        public FranchiseRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Franchise> Franchise => _context.Set<Domain.Entities.Franchise>();

        public async Task Add(Domain.Entities.Franchise franchise, CancellationToken cancellationToken = default)
        {
            _context.Add(franchise);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Franchise franchise, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Franchise>().Remove(franchise);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Franchise> Get(int id)
        {
            return await Franchise.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Franchise>> GetAll()
        {
            return await Franchise.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Franchise franchise, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Franchise>().Update(franchise);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
