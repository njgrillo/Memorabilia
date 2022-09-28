using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class SizeRepository : BaseRepository<Size>, ISizeRepository
    {
        private readonly DomainContext _context;

        public SizeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Size> Size => _context.Set<Size>();

        public async Task Add(Size size, CancellationToken cancellationToken = default)
        {
            _context.Add(size);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Size size, CancellationToken cancellationToken = default)
        {
            _context.Set<Size>().Remove(size);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Size> Get(int id)
        {
            return await Size.SingleOrDefaultAsync(size => size.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Size>> GetAll()
        {
            return (await Size.ToListAsync().ConfigureAwait(false)).OrderBy(size => size.Name);
        }

        public async Task Update(Size size, CancellationToken cancellationToken = default)
        {
            _context.Set<Size>().Update(size);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
