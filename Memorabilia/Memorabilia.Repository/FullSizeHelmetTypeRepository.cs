using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class FullSizeHelmetTypeRepository : BaseRepository<Domain.Entities.FullSizeHelmetType>, IFullSizeHelmetTypeRepository
    {
        private readonly Context _context;

        public FullSizeHelmetTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.FullSizeHelmetType> FullSizeHelmetType => _context.Set<Domain.Entities.FullSizeHelmetType>();

        public async Task Add(Domain.Entities.FullSizeHelmetType fullSizeHelmetType, CancellationToken cancellationToken = default)
        {
            _context.Add(fullSizeHelmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.FullSizeHelmetType fullSizeHelmetType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FullSizeHelmetType>().Remove(fullSizeHelmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.FullSizeHelmetType> Get(int id)
        {
            return await FullSizeHelmetType.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.FullSizeHelmetType>> GetAll()
        {
            return await FullSizeHelmetType.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.FullSizeHelmetType fullSizeHelmetType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.FullSizeHelmetType>().Update(fullSizeHelmetType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
