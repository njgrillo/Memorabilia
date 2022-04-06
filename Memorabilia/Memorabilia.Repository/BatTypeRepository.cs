using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class BatTypeRepository : BaseRepository<BatType>, IBatTypeRepository
    {
        private readonly DomainContext _context;

        public BatTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<BatType> BatType => _context.Set<BatType>();

        public async Task Add(BatType batType, CancellationToken cancellationToken = default)
        {
            _context.Add(batType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(BatType batType, CancellationToken cancellationToken = default)
        {
            _context.Set<BatType>().Remove(batType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<BatType> Get(int id)
        {
            return await BatType.SingleOrDefaultAsync(batType => batType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BatType>> GetAll()
        {
            return (await BatType.ToListAsync().ConfigureAwait(false)).OrderBy(batType => batType.Name);
        }

        public async Task Update(BatType batType, CancellationToken cancellationToken = default)
        {
            _context.Set<BatType>().Update(batType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
