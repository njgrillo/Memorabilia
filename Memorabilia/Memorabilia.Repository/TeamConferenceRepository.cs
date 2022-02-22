using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class TeamConferenceRepository : BaseRepository<Domain.Entities.TeamConference>, ITeamConferenceRepository
    {
        private readonly Context _context;

        public TeamConferenceRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.TeamConference> TeamConference => _context.Set<Domain.Entities.TeamConference>()
                                                                                     .Include(teamConference => teamConference.Team);

        public async Task Add(Domain.Entities.TeamConference teamConference, CancellationToken cancellationToken = default)
        {
            _context.Add(teamConference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.TeamConference teamConference, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.TeamConference>().Remove(teamConference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.TeamConference> Get(int id)
        {
            return await TeamConference.SingleOrDefaultAsync(teamConference => teamConference.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.TeamConference>> GetAll(int? teamId = null)
        {
            return teamId.HasValue 
                ? (await TeamConference.Where(teamConference => teamConference.TeamId == teamId)
                                       .ToListAsync()
                                       .ConfigureAwait(false)).OrderBy(teamConference => teamConference.ConferenceName)
                                                              .ThenBy(teamConference => teamConference.Team?.Name)
                : (await TeamConference.ToListAsync()
                                       .ConfigureAwait(false)).OrderBy(teamConference => teamConference.ConferenceName)
                                                              .ThenBy(teamConference => teamConference.Team?.Name);
        }

        public async Task Update(Domain.Entities.TeamConference teamConference, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.TeamConference>().Update(teamConference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
