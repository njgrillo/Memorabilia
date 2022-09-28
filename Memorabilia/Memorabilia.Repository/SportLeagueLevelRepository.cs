using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class SportLeagueLevelRepository : BaseRepository<SportLeagueLevel>, ISportLeagueLevelRepository
    {
        private readonly DomainContext _context;

        public SportLeagueLevelRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<SportLeagueLevel> SportLeagueLevel => _context.Set<SportLeagueLevel>();

        public async Task Add(SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default)
        {
            _context.Add(sportLeagueLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default)
        {
            _context.Set<SportLeagueLevel>().Remove(sportLeagueLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<SportLeagueLevel> Get(int id)
        {
            return await SportLeagueLevel.SingleOrDefaultAsync(sportLeagueLevel => sportLeagueLevel.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<SportLeagueLevel>> GetAll()
        {
            return (await SportLeagueLevel.ToListAsync()
                                          .ConfigureAwait(false)).OrderBy(sportLeagueLevel => sportLeagueLevel.SportName)
                                                                 .ThenBy(sportLeagueLevel => sportLeagueLevel.Name);
        }

        public async Task Update(SportLeagueLevel sportLeagueLevel, CancellationToken cancellationToken = default)
        {
            _context.Set<SportLeagueLevel>().Update(sportLeagueLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
