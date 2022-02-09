using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBaseballRepository : BaseRepository<Domain.Entities.MemorabiliaBaseball>, IMemorabiliaBaseballRepository
    {
        private readonly Context _context;

        public MemorabiliaBaseballRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaBaseball> MemorabiliaBaseball => _context.Set<Domain.Entities.MemorabiliaBaseball>();

        public async Task Add(Domain.Entities.MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBaseball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBaseball>().Remove(memorabiliaBaseball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaBaseball> Get(int id)
        {
            return await MemorabiliaBaseball.SingleOrDefaultAsync(memorabiliaBaseball => memorabiliaBaseball.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaBaseball memorabiliaBaseball, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBaseball>().Update(memorabiliaBaseball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
