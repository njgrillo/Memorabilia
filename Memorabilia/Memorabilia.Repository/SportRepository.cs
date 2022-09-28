using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class SportRepository : BaseRepository<Sport>, ISportRepository
    {
        private readonly DomainContext _context;

        public SportRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Sport> Sport => _context.Set<Sport>();

        public async Task Add(Sport sport, CancellationToken cancellationToken = default)
        {
            _context.Add(sport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Sport sport, CancellationToken cancellationToken = default)
        {
            _context.Set<Sport>().Remove(sport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Sport> Get(int id)
        {
            return await Sport.SingleOrDefaultAsync(sport => sport.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Sport>> GetAll()
        {
            return (await Sport.ToListAsync().ConfigureAwait(false)).OrderBy(sport => sport.Name);
        }

        public async Task Update(Sport sport, CancellationToken cancellationToken = default)
        {
            _context.Set<Sport>().Update(sport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
