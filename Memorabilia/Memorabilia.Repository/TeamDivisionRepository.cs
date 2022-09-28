using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class TeamDivisionRepository : BaseRepository<TeamDivision>, ITeamDivisionRepository
    {
        private readonly DomainContext _context;

        public TeamDivisionRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<TeamDivision> TeamDivision => _context.Set<TeamDivision>()
                                                                 .Include(teamDivision => teamDivision.Team);

        public async Task Add(TeamDivision teamDivision, CancellationToken cancellationToken = default)
        {
            _context.Add(teamDivision);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(TeamDivision teamDivision, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamDivision>().Remove(teamDivision);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TeamDivision> Get(int id)
        {
            return await TeamDivision.SingleOrDefaultAsync(teamDivision => teamDivision.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TeamDivision>> GetAll(int? teamId = null)
        {
            return teamId.HasValue 
                ? (await TeamDivision.Where(teamDivision => teamDivision.TeamId == teamId) 
                                     .ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(teamDivision => teamDivision.DivisionName)
                                                            .ThenBy(teamDivision => teamDivision.Team?.Name)
                : (await TeamDivision.ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(teamDivision => teamDivision.DivisionName)
                                                            .ThenBy(teamDivision => teamDivision.Team?.Name);
        }

        public async Task Update(TeamDivision teamDivision, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamDivision>().Update(teamDivision);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
