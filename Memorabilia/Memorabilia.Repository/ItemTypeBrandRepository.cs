using Memorabilia.Domain;
using Memorabilia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ItemTypeBrandRepository : BaseRepository<ItemTypeBrand>, IItemTypeBrandRepository
    {
        private readonly Context _context;

        public ItemTypeBrandRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemTypeBrand> ItemTypeBrand => _context.Set<ItemTypeBrand>();

        public async Task Add(ItemTypeBrand itemTypeBrand, CancellationToken cancellationToken = default)
        {
            _context.Add(itemTypeBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemTypeBrand itemTypeBrand, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeBrand>().Remove(itemTypeBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemTypeBrand> Get(int id)
        {
            return await ItemTypeBrand.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemTypeBrand>> GetAll(int? itemTypeId = null)
        {
            return !itemTypeId.HasValue
                ? await ItemTypeBrand.ToListAsync().ConfigureAwait(false)
                : await ItemTypeBrand.Where(itemTypeBrand => itemTypeBrand.ItemTypeId == itemTypeId).ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(ItemTypeBrand itemTypeBrand, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeBrand>().Update(itemTypeBrand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
