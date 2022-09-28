using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class JerseyQualityTypeRepository : BaseRepository<JerseyQualityType>, IJerseyQualityTypeRepository
    {
        private readonly DomainContext _context;

        public JerseyQualityTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<JerseyQualityType> JerseyQualityType => _context.Set<JerseyQualityType>();

        public async Task Add(JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<JerseyQualityType>().Remove(jerseyQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<JerseyQualityType> Get(int id)
        {
            return await JerseyQualityType.SingleOrDefaultAsync(jerseyQualityType => jerseyQualityType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<JerseyQualityType>> GetAll()
        {
            return (await JerseyQualityType.ToListAsync().ConfigureAwait(false)).OrderBy(jerseyQualityType => jerseyQualityType.Name);
        }

        public async Task Update(JerseyQualityType jerseyQualityType, CancellationToken cancellationToken = default)
        {
            _context.Set<JerseyQualityType>().Update(jerseyQualityType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
