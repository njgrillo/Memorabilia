﻿using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;

namespace Memorabilia.Repository
{
    public class BrandRepository : BaseRepository<Domain.Entities.Brand>, IBrandRepository
    {
        private readonly Context _context;

        public BrandRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Brand> Brand => _context.Set<Domain.Entities.Brand>();

        public async Task Add(Domain.Entities.Brand brand, CancellationToken cancellationToken = default)
        {
            _context.Add(brand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Brand brand, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Brand>().Remove(brand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Brand> Get(int id)
        {
            return await Brand.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Brand>> GetAll()
        {
            return await Brand.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Brand brand, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Brand>().Update(brand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
