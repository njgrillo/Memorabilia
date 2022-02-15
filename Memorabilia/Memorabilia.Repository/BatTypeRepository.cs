using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class BatTypeRepository : BaseRepository<Domain.Entities.BatType>, IBatTypeRepository
    {
        private readonly Context _context;

        public BatTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.BatType> BatType => _context.Set<Domain.Entities.BatType>();

        public async Task Add(Domain.Entities.BatType batType, CancellationToken cancellationToken = default)
        {
            _context.Add(batType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.BatType batType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.BatType>().Remove(batType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.BatType> Get(int id)
        {
            return await BatType.SingleOrDefaultAsync(batType => batType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.BatType>> GetAll()
        {
            return (await BatType.ToListAsync().ConfigureAwait(false)).OrderBy(batType => batType.Name);
        }

        public async Task Update(Domain.Entities.BatType batType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.BatType>().Update(batType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
