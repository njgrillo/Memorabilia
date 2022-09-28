using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class BammerTypeRepository : BaseRepository<BammerType>, IBammerTypeRepository
    {
        private readonly DomainContext _context;

        public BammerTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<BammerType> BammerType => _context.Set<BammerType>();

        public async Task Add(BammerType BammerType, CancellationToken cancellationToken = default)
        {
            _context.Add(BammerType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(BammerType BammerType, CancellationToken cancellationToken = default)
        {
            _context.Set<BammerType>().Remove(BammerType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<BammerType> Get(int id)
        {
            return await BammerType.SingleOrDefaultAsync(BammerType => BammerType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BammerType>> GetAll()
        {
            return (await BammerType.ToListAsync().ConfigureAwait(false)).OrderBy(BammerType => BammerType.Name);
        }

        public async Task Update(BammerType BammerType, CancellationToken cancellationToken = default)
        {
            _context.Set<BammerType>().Update(BammerType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
