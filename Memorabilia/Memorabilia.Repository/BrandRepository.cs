using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly DomainContext _context;

        public BrandRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Brand> Brand => _context.Set<Brand>();

        public async Task Add(Brand brand, CancellationToken cancellationToken = default)
        {
            _context.Add(brand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Brand brand, CancellationToken cancellationToken = default)
        {
            _context.Set<Brand>().Remove(brand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Brand> Get(int id)
        {
            return await Brand.SingleOrDefaultAsync(brand => brand.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return (await Brand.ToListAsync().ConfigureAwait(false)).OrderBy(brand => brand.Name);
        }

        public async Task Update(Brand brand, CancellationToken cancellationToken = default)
        {
            _context.Set<Brand>().Update(brand);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
