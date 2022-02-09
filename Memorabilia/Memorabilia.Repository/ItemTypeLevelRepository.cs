using Memorabilia.Domain;
using Memorabilia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ItemTypeLevelRepository : BaseRepository<ItemTypeLevel>, IItemTypeLevelRepository
    {
        private readonly Context _context;

        public ItemTypeLevelRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemTypeLevel> ItemTypeLevel => _context.Set<ItemTypeLevel>();

        public async Task Add(ItemTypeLevel itemTypeLevel, CancellationToken cancellationToken = default)
        {
            _context.Add(itemTypeLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemTypeLevel itemTypeLevel, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeLevel>().Remove(itemTypeLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemTypeLevel> Get(int id)
        {
            return await ItemTypeLevel.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemTypeLevel>> GetAll(int? itemTypeId = null)
        {
            return !itemTypeId.HasValue
                ? await ItemTypeLevel.ToListAsync().ConfigureAwait(false)
                : await ItemTypeLevel.Where(itemTypeLevelType => itemTypeLevelType.ItemTypeId == itemTypeId).ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(ItemTypeLevel itemTypeLevel, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeLevel>().Update(itemTypeLevel);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
