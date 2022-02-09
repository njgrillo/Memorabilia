using Memorabilia.Domain;
using Memorabilia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ItemTypeAuthenticTypeRepository : BaseRepository<ItemTypeAuthenticType>, IItemTypeAuthenticTypeRepository
    {
        private readonly Context _context;

        public ItemTypeAuthenticTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemTypeAuthenticType> ItemTypeAuthenticType => _context.Set<ItemTypeAuthenticType>();

        public async Task Add(ItemTypeAuthenticType itemTypeAuthenticType, CancellationToken cancellationToken = default)
        {
            _context.Add(itemTypeAuthenticType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemTypeAuthenticType itemTypeAuthenticType, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeAuthenticType>().Remove(itemTypeAuthenticType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemTypeAuthenticType> Get(int id)
        {
            return await ItemTypeAuthenticType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemTypeAuthenticType>> GetAll(int? itemTypeId = null)
        {
            return !itemTypeId.HasValue
                ? await ItemTypeAuthenticType.ToListAsync().ConfigureAwait(false)
                : await ItemTypeAuthenticType.Where(itemTypeAuthenticType => itemTypeAuthenticType.ItemTypeId == itemTypeId).ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(ItemTypeAuthenticType itemTypeAuthenticType, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeAuthenticType>().Update(itemTypeAuthenticType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
