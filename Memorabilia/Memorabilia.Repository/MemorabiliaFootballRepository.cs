using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaFootballRepository : BaseRepository<MemorabiliaFootball>, IMemorabiliaFootballRepository
    {
        private readonly Context _context;

        public MemorabiliaFootballRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaFootball> MemorabiliaFootball => _context.Set<MemorabiliaFootball>();

        public async Task Add(MemorabiliaFootball memorabiliaFootball, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaFootball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaFootball memorabiliaFootball, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaFootball>().Remove(memorabiliaFootball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaFootball> Get(int id)
        {
            return await MemorabiliaFootball.SingleOrDefaultAsync(memorabiliaFootball => memorabiliaFootball.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaFootball memorabiliaFootball, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaFootball>().Update(memorabiliaFootball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
