using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaSizeRepository : BaseRepository<MemorabiliaSize>, IMemorabiliaSizeRepository
    {
        private readonly Context _context;

        public MemorabiliaSizeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaSize> MemorabiliaSize => _context.Set<MemorabiliaSize>();

        public async Task Add(MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaSize>().Remove(memorabiliaSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaSize> Get(int id)
        {
            return await MemorabiliaSize.SingleOrDefaultAsync(memorabiliaSize => memorabiliaSize.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaSize memorabiliaSize, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaSize>().Update(memorabiliaSize);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
