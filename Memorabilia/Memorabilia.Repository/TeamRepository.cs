using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class TeamRepository : BaseRepository<Team>, ITeamRepository
    {
        private readonly DomainContext _context;

        public TeamRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Team> Team => _context.Set<Team>()
                                                 .Include(team => team.Conferences)
                                                 .Include(team => team.Divisions)
                                                 .Include(team => team.Franchise)
                                                 .Include(team => team.Leagues);

        public async Task Add(Team team, CancellationToken cancellationToken = default)
        {
            _context.Add(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Team team, CancellationToken cancellationToken = default)
        {
            _context.Set<Team>().Remove(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Team> Get(int id)
        {
            return await Team.SingleOrDefaultAsync(team => team.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Team>> GetAll(int? franchiseId = null, int? sportLeageLevelId = null)
        {
            if (franchiseId.HasValue)
            {
                return (await Team.Where(team => team.FranchiseId == franchiseId)
                                  .ToListAsync()
                                  .ConfigureAwait(false)).OrderBy(team => team.Name);
            }

            if (sportLeageLevelId.HasValue)
            {
                return (await Team.Where(team => team.Franchise.SportLeagueLevelId == sportLeageLevelId)
                                  .ToListAsync()
                                  .ConfigureAwait(false)).OrderBy(team => team.Franchise.SportLeagueLevelName)
                                                         .ThenBy(team => team.Name);
            }

            return (await Team.ToListAsync()
                              .ConfigureAwait(false)).OrderBy(team => team.Franchise.SportLeagueLevelName)
                                                     .ThenBy(team => team.Name);
        }

        public async Task Update(Team team, CancellationToken cancellationToken = default)
        {
            _context.Set<Team>().Update(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
