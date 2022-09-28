using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class GloveTypeRepository : BaseRepository<GloveType>, IGloveTypeRepository
    {
        private readonly DomainContext _context;

        public GloveTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<GloveType> GloveType => _context.Set<GloveType>();

        public async Task Add(GloveType gloveType, CancellationToken cancellationToken = default)
        {
            _context.Add(gloveType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(GloveType gloveType, CancellationToken cancellationToken = default)
        {
            _context.Set<GloveType>().Remove(gloveType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<GloveType> Get(int id)
        {
            return await GloveType.SingleOrDefaultAsync(gloveType => gloveType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<GloveType>> GetAll()
        {
            return (await GloveType.ToListAsync().ConfigureAwait(false)).OrderBy(gloveType => gloveType.Name);
        }

        public async Task Update(GloveType gloveType, CancellationToken cancellationToken = default)
        {
            _context.Set<GloveType>().Update(gloveType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
