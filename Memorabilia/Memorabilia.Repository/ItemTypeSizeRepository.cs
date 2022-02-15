using Memorabilia.Domain;
using Memorabilia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ItemTypeSizeRepository : BaseRepository<ItemTypeSize>, IItemTypeSizeRepository
    {
        private readonly Context _context;

        public ItemTypeSizeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemTypeSize> ItemTypeSize => _context.Set<ItemTypeSize>();

        public async Task Add(ItemTypeSize itemTypeSize, CancellationToken cancellationToken = default)
        {
            _context.Add(itemTypeSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemTypeSize itemTypeSize, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeSize>().Remove(itemTypeSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemTypeSize> Get(int id)
        {
            return await ItemTypeSize.SingleOrDefaultAsync(itemTypeSize => itemTypeSize.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemTypeSize>> GetAll(int? itemTypeId = null)
        {
            return !itemTypeId.HasValue 
                ? (await ItemTypeSize.ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(itemTypeSize => itemTypeSize.ItemTypeName)
                                                            .ThenBy(itemTypeSize => itemTypeSize.SizeName)
                : (await ItemTypeSize.Where(itemTypeSize => itemTypeSize.ItemTypeId == itemTypeId)
                                     .ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(itemTypeSize => itemTypeSize.ItemTypeName)
                                                            .ThenBy(itemTypeSize => itemTypeSize.SizeName);
        }

        public async Task Update(ItemTypeSize itemTypeSize, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeSize>().Update(itemTypeSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}