using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class LeagueRepository : BaseRepository<League>, ILeagueRepository
    {
        private readonly DomainContext _context;

        public LeagueRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<League> League => _context.Set<League>();

        public async Task Add(League league, CancellationToken cancellationToken = default)
        {
            _context.Add(league);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(League league, CancellationToken cancellationToken = default)
        {
            _context.Set<League>().Remove(league);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<League> Get(int id)
        {
            return await League.SingleOrDefaultAsync(league => league.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<League>> GetAll()
        {
            return (await League.ToListAsync().ConfigureAwait(false)).OrderBy(League => League.Name);
        }

        public async Task Update(League league, CancellationToken cancellationToken = default)
        {
            _context.Set<League>().Update(league);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
