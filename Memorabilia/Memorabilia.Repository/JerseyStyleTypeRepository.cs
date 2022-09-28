using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class JerseyStyleTypeRepository : BaseRepository<JerseyStyleType>, IJerseyStyleTypeRepository
    {
        private readonly DomainContext _context;

        public JerseyStyleTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<JerseyStyleType> JerseyStyleType => _context.Set<JerseyStyleType>();

        public async Task Add(JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default)
        {
            _context.Add(jerseyStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<JerseyStyleType>().Remove(jerseyStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<JerseyStyleType> Get(int id)
        {
            return await JerseyStyleType.SingleOrDefaultAsync(jerseyStyleType => jerseyStyleType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<JerseyStyleType>> GetAll()
        {
            return (await JerseyStyleType.ToListAsync().ConfigureAwait(false)).OrderBy(jerseyStyleType => jerseyStyleType.Name);
        }

        public async Task Update(JerseyStyleType jerseyStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<JerseyStyleType>().Update(jerseyStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}