using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class TeamLeagueRepository : BaseRepository<TeamLeague>, ITeamLeagueRepository
    {
        private readonly DomainContext _context;

        public TeamLeagueRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<TeamLeague> TeamLeague => _context.Set<TeamLeague>()
                                                             .Include(teamLeague => teamLeague.Team);

        public async Task Add(TeamLeague teamLeague, CancellationToken cancellationToken = default)
        {
            _context.Add(teamLeague);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(TeamLeague teamLeague, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamLeague>().Remove(teamLeague);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TeamLeague> Get(int id)
        {
            return await TeamLeague.SingleOrDefaultAsync(teamLeague => teamLeague.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TeamLeague>> GetAll(int? teamId = null)
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

        public async Task Update(TeamLeague teamLeague, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamLeague>().Update(teamLeague);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
