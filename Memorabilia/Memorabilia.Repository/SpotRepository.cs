using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class SpotRepository : BaseRepository<Spot>, ISpotRepository
    {
        private readonly DomainContext _context;

        public SpotRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Spot> Spot => _context.Set<Spot>();

        public async Task Add(Spot spot, CancellationToken cancellationToken = default)
        {
            _context.Add(spot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Spot spot, CancellationToken cancellationToken = default)
        {
            _context.Set<Spot>().Remove(spot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Spot> Get(int id)
        {
            return await Spot.SingleOrDefaultAsync(spot => spot.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Spot>> GetAll()
        {
            return (await Spot.ToListAsync().ConfigureAwait(false)).OrderBy(spot => spot.Name);
        }

        public async Task Update(Spot spot, CancellationToken cancellationToken = default)
        {
            _context.Set<Spot>().Update(spot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
