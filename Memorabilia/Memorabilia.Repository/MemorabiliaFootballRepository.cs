using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaFootballRepository : BaseRepository<Domain.Entities.MemorabiliaFootball>, IMemorabiliaFootballRepository
    {
        private readonly Context _context;

        public MemorabiliaFootballRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaFootball> MemorabiliaFootball => _context.Set<Domain.Entities.MemorabiliaFootball>();

        public async Task Add(Domain.Entities.MemorabiliaFootball memorabiliaFootball, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaFootball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaFootball memorabiliaFootball, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaFootball>().Remove(memorabiliaFootball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaFootball> Get(int id)
        {
            return await MemorabiliaFootball.SingleOrDefaultAsync(memorabiliaFootball => memorabiliaFootball.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaFootball memorabiliaFootball, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaFootball>().Update(memorabiliaFootball);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
