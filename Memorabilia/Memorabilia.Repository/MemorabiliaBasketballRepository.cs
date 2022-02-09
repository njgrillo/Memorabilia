using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBasketballRepository : BaseRepository<Domain.Entities.MemorabiliaBasketball>, IMemorabiliaBasketballRepository
    {
        private readonly Context _context;

        public MemorabiliaBasketballRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaBasketball> MemorabiliaBasketball => _context.Set<Domain.Entities.MemorabiliaBasketball>();

        public async Task Add(Domain.Entities.MemorabiliaBasketball memorabiliaBasketball, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBasketball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaBasketball memorabiliaBasketball, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBasketball>().Remove(memorabiliaBasketball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaBasketball> Get(int id)
        {
            return await MemorabiliaBasketball.SingleOrDefaultAsync(memorabiliaBasketball => memorabiliaBasketball.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaBasketball memorabiliaBasketball, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBasketball>().Update(memorabiliaBasketball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
