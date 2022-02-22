using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class TeamLeagueRepository : BaseRepository<Domain.Entities.TeamLeague>, ITeamLeagueRepository
    {
        private readonly Context _context;

        public TeamLeagueRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.TeamLeague> TeamLeague => _context.Set<Domain.Entities.TeamLeague>()
                                                                             .Include(teamLeague => teamLeague.Team);

        public async Task Add(Domain.Entities.TeamLeague teamLeague, CancellationToken cancellationToken = default)
        {
            _context.Add(teamLeague);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.TeamLeague teamLeague, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.TeamLeague>().Remove(teamLeague);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.TeamLeague> Get(int id)
        {
            return await TeamLeague.SingleOrDefaultAsync(teamLeague => teamLeague.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.TeamLeague>> GetAll(int? teamId = null)
        {
            return teamId.HasValue 
                ? (await TeamLeague.Where(teamLeague => teamLeague.TeamId == teamId)
                                   .ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(teamLeague => teamLeague.LeagueName)
                                                          .ThenBy(teamLeague => teamLeague.Team?.Name)
                : (await TeamLeague.ToListAsync()
                                   .ConfigureAwait(false)).OrderBy(teamLeague => teamLeague.LeagueName)
                                                          .ThenBy(teamLeague => teamLeague.Team?.Name);
        }

        public async Task Update(Domain.Entities.TeamLeague teamLeague, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.TeamLeague>().Update(teamLeague);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
