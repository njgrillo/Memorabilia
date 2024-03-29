﻿using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class SizeRepository : BaseRepository<Domain.Entities.Size>, ISizeRepository
    {
        private readonly Context _context;

        public SizeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Size> Size => _context.Set<Domain.Entities.Size>();

        public async Task Add(Domain.Entities.Size size, CancellationToken cancellationToken = default)
        {
            _context.Add(size);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Size size, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Size>().Remove(size);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Size> Get(int id)
        {
            return await Size.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Size>> GetAll()
        {
            return await Size.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Size size, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Size>().Update(size);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
