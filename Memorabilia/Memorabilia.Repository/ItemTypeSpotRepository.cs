using Memorabilia.Domain;
using Memorabilia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ItemTypeSpotRepository : BaseRepository<ItemTypeSpot>, IItemTypeSpotRepository
    {
        private readonly Context _context;

        public ItemTypeSpotRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemTypeSpot> ItemTypeSpot => _context.Set<ItemTypeSpot>();

        public async Task Add(ItemTypeSpot itemTypeSpot, CancellationToken cancellationToken = default)
        {
            _context.Add(itemTypeSpot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemTypeSpot itemTypeSpot, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeSpot>().Remove(itemTypeSpot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemTypeSpot> Get(int id)
        {
            return await ItemTypeSpot.SingleOrDefaultAsync(itemTypeSpot => itemTypeSpot.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemTypeSpot>> GetAll(int? itemTypeId = null)
        {
            return !itemTypeId.HasValue
                ? (await ItemTypeSpot.ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(itemTypeSpot => itemTypeSpot.ItemTypeName)
                                                            .ThenBy(itemTypeSpot => itemTypeSpot.SpotName)
                : (await ItemTypeSpot.Where(itemTypeSpot => itemTypeSpot.ItemTypeId == itemTypeId)
                                     .ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(itemTypeSpot => itemTypeSpot.ItemTypeName)
                                                            .ThenBy(itemTypeSpot => itemTypeSpot.SpotName);
        }

        public async Task Update(ItemTypeSpot itemTypeSpot, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeSpot>().Update(itemTypeSpot);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
