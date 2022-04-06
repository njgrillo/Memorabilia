using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBaseballRepository : BaseRepository<MemorabiliaBaseball>, IMemorabiliaBaseballRepository
    {
        private readonly Context _context;

        public MemorabiliaBaseballRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaBaseball> MemorabiliaBaseball => _context.Set<MemorabiliaBaseball>();

        public async Task Add(MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBaseball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBaseball>().Remove(memorabiliaBaseball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaBaseball> Get(int id)
        {
            return await MemorabiliaBaseball.SingleOrDefaultAsync(memorabiliaBaseball => memorabiliaBaseball.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBaseball>().Update(memorabiliaBaseball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
