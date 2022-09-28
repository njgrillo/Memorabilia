using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class BasketballTypeRepository : BaseRepository<BasketballType>, IBasketballTypeRepository
    {
        private readonly DomainContext _context;

        public BasketballTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<BasketballType> BasketballType => _context.Set<BasketballType>();

        public async Task Add(BasketballType basketballType, CancellationToken cancellationToken = default)
        {
            _context.Add(basketballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(BasketballType basketballType, CancellationToken cancellationToken = default)
        {
            _context.Set<BasketballType>().Remove(basketballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<BasketballType> Get(int id)
        {
            return await BasketballType.SingleOrDefaultAsync(basketballType => basketballType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BasketballType>> GetAll()
        {
            return (await BasketballType.ToListAsync().ConfigureAwait(false)).OrderBy(basketballType => basketballType.Name);
        }

        public async Task Update(BasketballType basketballType, CancellationToken cancellationToken = default)
        {
            _context.Set<BasketballType>().Update(basketballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
