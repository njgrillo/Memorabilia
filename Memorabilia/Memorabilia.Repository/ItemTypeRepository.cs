using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository
{
    public class ItemTypeRepository : BaseRepository<ItemType>, IItemTypeRepository
    {
        private readonly DomainContext _context;

        public ItemTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemType> ItemType => _context.Set<ItemType>();

        public async Task Add(ItemType itemType, CancellationToken cancellationToken = default)
        {
            _context.Add(itemType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemType itemType, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemType>().Remove(itemType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemType> Get(int id)
        {
            return await ItemType.SingleOrDefaultAsync(itemType => itemType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemType>> GetAll()
        {
            return (await ItemType.ToListAsync().ConfigureAwait(false)).OrderBy(itemType => itemType.Name);
        }

        public async Task Update(ItemType itemType, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemType>().Update(itemType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
