using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class SpotRepository : BaseRepository<Domain.Entities.Spot>, ISpotRepository
    {
        private readonly Context _context;

        public SpotRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Spot> Spot => _context.Set<Domain.Entities.Spot>();

        public async Task Add(Domain.Entities.Spot spot, CancellationToken cancellationToken = default)
        {
            _context.Add(spot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Spot spot, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Spot>().Remove(spot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Spot> Get(int id)
        {
            return await Spot.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Spot>> GetAll()
        {
            return await Spot.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Spot spot, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Spot>().Update(spot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
