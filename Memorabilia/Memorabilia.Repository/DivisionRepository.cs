using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class DivisionRepository : BaseRepository<Division>, IDivisionRepository
    {
        private readonly DomainContext _context;

        public DivisionRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Division> Division => _context.Set<Division>();

        public async Task Add(Division division, CancellationToken cancellationToken = default)
        {
            _context.Add(division);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Division division, CancellationToken cancellationToken = default)
        {
            _context.Set<Division>().Remove(division);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Division> Get(int id)
        {
            return await Division.SingleOrDefaultAsync(division => division.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Division>> GetAll()
        {
            return (await Division.ToListAsync().ConfigureAwait(false)).OrderBy(Division => Division.Name);
        }

        public async Task Update(Division division, CancellationToken cancellationToken = default)
        {
            _context.Set<Division>().Update(division);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
