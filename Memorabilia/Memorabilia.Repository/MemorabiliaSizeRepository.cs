using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaSizeRepository : BaseRepository<Domain.Entities.MemorabiliaSize>, IMemorabiliaSizeRepository
    {
        private readonly Context _context;

        public MemorabiliaSizeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaSize> MemorabiliaSize => _context.Set<Domain.Entities.MemorabiliaSize>();

        public async Task Add(Domain.Entities.MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaSize>().Remove(memorabiliaSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaSize> Get(int id)
        {
            return await MemorabiliaSize.SingleOrDefaultAsync(memorabiliaSize => memorabiliaSize.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaSize>().Update(memorabiliaSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
