using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class SportLeagueLevelRepository : BaseRepository<Domain.Entities.SportLeagueLevel>, ISportLeagueLevelRepository
    {
        private readonly Context _context;

        public SportLeagueLevelRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.SportLeagueLevel> SportLeagueLevel => _context.Set<Domain.Entities.SportLeagueLevel>();

        public async Task Add(Domain.Entities.SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default)
        {
            _context.Add(sportLeagueLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.SportLeagueLevel>().Remove(sportLeagueLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.SportLeagueLevel> Get(int id)
        {
            return await SportLeagueLevel.SingleOrDefaultAsync(sportLeagueLevel => sportLeagueLevel.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.SportLeagueLevel>> GetAll()
        {
            return (await SportLeagueLevel.ToListAsync()
                                          .ConfigureAwait(false)).OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                                                                 .ThenBy(sportLeagueLevel => sportLeagueLevel.Name);
        }

        public async Task Update(Domain.Entities.SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.SportLeagueLevel>().Update(sportLeagueLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
