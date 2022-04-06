using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBasketballRepository : BaseRepository<MemorabiliaBasketball>, IMemorabiliaBasketballRepository
    {
        private readonly Context _context;

        public MemorabiliaBasketballRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaBasketball> MemorabiliaBasketball => _context.Set<MemorabiliaBasketball>();

        public async Task Add(MemorabiliaBasketball memorabiliaBasketball, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBasketball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaBasketball memorabiliaBasketball, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBasketball>().Remove(memorabiliaBasketball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaBasketball> Get(int id)
        {
            return await MemorabiliaBasketball.SingleOrDefaultAsync(memorabiliaBasketball => memorabiliaBasketball.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaBasketball memorabiliaBasketball, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBasketball>().Update(memorabiliaBasketball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
