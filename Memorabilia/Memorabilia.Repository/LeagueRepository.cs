using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class LeagueRepository : BaseRepository<Domain.Entities.League>, ILeagueRepository
    {
        private readonly Context _context;

        public LeagueRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.League> League => _context.Set<Domain.Entities.League>();

        public async Task Add(Domain.Entities.League league, CancellationToken cancellationToken = default)
        {
            _context.Add(league);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.League league, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.League>().Remove(league);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.League> Get(int id)
        {
            return await League.SingleOrDefaultAsync(league => league.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.League>> GetAll()
        {
            return (await League.ToListAsync().ConfigureAwait(false)).OrderBy(League => League.Name);
        }

        public async Task Update(Domain.Entities.League league, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.League>().Update(league);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
