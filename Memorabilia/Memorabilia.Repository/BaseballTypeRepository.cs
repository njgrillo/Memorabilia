using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class BaseballTypeRepository : BaseRepository<BaseballType>, IBaseballTypeRepository
    {
        private readonly DomainContext _context;

        public BaseballTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<BaseballType> BaseballType => _context.Set<BaseballType>();

        public async Task Add(BaseballType baseballType, CancellationToken cancellationToken = default)
        {
            _context.Add(baseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(BaseballType baseballType, CancellationToken cancellationToken = default)
        {
            _context.Set<BaseballType>().Remove(baseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<BaseballType> Get(int id)
        {
            return await BaseballType.SingleOrDefaultAsync(baseballType => baseballType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BaseballType>> GetAll()
        {
            return (await BaseballType.ToListAsync().ConfigureAwait(false)).OrderBy(baseballType => baseballType.Name);
        }

        public async Task Update(BaseballType baseballType, CancellationToken cancellationToken = default)
        {
            _context.Set<BaseballType>().Update(baseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
