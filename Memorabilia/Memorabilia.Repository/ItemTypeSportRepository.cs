using Memorabilia.Domain;
using Memorabilia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ItemTypeSportRepository : BaseRepository<ItemTypeSport>, IItemTypeSportRepository
    {
        private readonly Context _context;

        public ItemTypeSportRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemTypeSport> ItemTypeSport => _context.Set<ItemTypeSport>();

        public async Task Add(ItemTypeSport itemTypeSport, CancellationToken cancellationToken = default)
        {
            _context.Add(itemTypeSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemTypeSport itemTypeSport, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeSport>().Remove(itemTypeSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemTypeSport> Get(int id)
        {
            return await ItemTypeSport.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemTypeSport>> GetAll(int? itemTypeId = null)
        {
            return !itemTypeId.HasValue
                ? await ItemTypeSport.ToListAsync().ConfigureAwait(false)
                : await ItemTypeSport.Where(itemTypeSport => itemTypeSport.ItemTypeId == itemTypeId).ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(ItemTypeSport itemTypeSport, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeSport>().Update(itemTypeSport);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
