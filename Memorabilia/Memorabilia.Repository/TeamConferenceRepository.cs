using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class TeamConferenceRepository : BaseRepository<TeamConference>, ITeamConferenceRepository
    {
        private readonly DomainContext _context;

        public TeamConferenceRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<TeamConference> TeamConference => _context.Set<TeamConference>()
                                                                     .Include(teamConference => teamConference.Team);

        public async Task Add(TeamConference teamConference, CancellationToken cancellationToken = default)
        {
            _context.Add(teamConference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(TeamConference teamConference, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamConference>().Remove(teamConference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TeamConference> Get(int id)
        {
            return await TeamConference.SingleOrDefaultAsync(teamConference => teamConference.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TeamConference>> GetAll(int? teamId = null)
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

        public async Task Update(TeamConference teamConference, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamConference>().Update(teamConference);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
