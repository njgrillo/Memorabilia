using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class SportRepository : BaseRepository<Domain.Entities.Sport>, ISportRepository
    {
        private readonly Context _context;

        public SportRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Sport> Sport => _context.Set<Domain.Entities.Sport>();

        public async Task Add(Domain.Entities.Sport sport, CancellationToken cancellationToken = default)
        {
            _context.Add(sport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Sport sport, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Sport>().Remove(sport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Sport> Get(int id)
        {
            return await Sport.SingleOrDefaultAsync(sport => sport.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Sport>> GetAll()
        {
            return (await Sport.ToListAsync().ConfigureAwait(false)).OrderBy(sport => sport.Name);
        }

        public async Task Update(Domain.Entities.Sport sport, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Sport>().Update(sport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
