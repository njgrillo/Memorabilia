using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class ItemTypeGameStyleTypeRepository : BaseRepository<ItemTypeGameStyleType>, IItemTypeGameStyleTypeRepository
    {
        private readonly DomainContext _context;

        public ItemTypeGameStyleTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<ItemTypeGameStyleType> ItemTypeGameStyleType => _context.Set<ItemTypeGameStyleType>();

        public async Task Add(ItemTypeGameStyleType itemTypeGameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Add(itemTypeGameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(ItemTypeGameStyleType itemTypeGameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeGameStyleType>().Remove(itemTypeGameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<ItemTypeGameStyleType> Get(int id)
        {
            return await ItemTypeGameStyleType.SingleOrDefaultAsync(itemTypeGameStyleType => itemTypeGameStyleType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ItemTypeGameStyleType>> GetAll(int? itemTypeId = null)
        {
            return !itemTypeId.HasValue
                ? (await ItemTypeGameStyleType.ToListAsync()
                                              .ConfigureAwait(false)).OrderBy(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeName)
                                                                     .ThenBy(itemTypeGameStyleType => itemTypeGameStyleType.GameStyleTypeName)
                : (await ItemTypeGameStyleType.Where(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeId == itemTypeId)
                                              .ToListAsync()
                                              .ConfigureAwait(false)).OrderBy(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeName)
                                                                     .ThenBy(itemTypeGameStyleType => itemTypeGameStyleType.GameStyleTypeName);
        }

        public async Task Update(ItemTypeGameStyleType itemTypeGameStyleType, CancellationToken cancellationToken = default)
        {
            _context.Set<ItemTypeGameStyleType>().Update(itemTypeGameStyleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
