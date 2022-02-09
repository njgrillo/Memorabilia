using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class OrientationRepository : BaseRepository<Domain.Entities.Orientation>, IOrientationRepository
    {
        private readonly Context _context;

        public OrientationRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Orientation> Orientation => _context.Set<Domain.Entities.Orientation>();

        public async Task Add(Domain.Entities.Orientation orientation, CancellationToken cancellationToken = default)
        {
            _context.Add(orientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Orientation orientation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Orientation>().Remove(orientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Orientation> Get(int id)
        {
            return await Orientation.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Orientation>> GetAll()
        {
            return await Orientation.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Orientation orientation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Orientation>().Update(orientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
