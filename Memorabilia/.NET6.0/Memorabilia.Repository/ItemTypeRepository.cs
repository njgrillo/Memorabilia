﻿using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class ItemTypeRepository : BaseRepository<Domain.Entities.ItemType>, IItemTypeRepository
    {
        private readonly Context _context;

        public ItemTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.ItemType> ItemType => _context.Set<Domain.Entities.ItemType>();

        public async Task Add(Domain.Entities.ItemType itemType, CancellationToken cancellationToken = default)
        {
            _context.Add(itemType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.ItemType itemType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.ItemType>().Remove(itemType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.ItemType> Get(int id)
        {
            return await ItemType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.ItemType>> GetAll()
        {
            return await ItemType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.ItemType itemType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.ItemType>().Update(itemType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
