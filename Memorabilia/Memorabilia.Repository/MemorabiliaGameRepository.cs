using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaGameRepository : BaseRepository<Domain.Entities.MemorabiliaGame>, IMemorabiliaGameRepository
    {
        private readonly Context _context;

        public MemorabiliaGameRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaGame> MemorabiliaGame => _context.Set<Domain.Entities.MemorabiliaGame>();

        public async Task Add(Domain.Entities.MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaGame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaGame>().Remove(memorabiliaGame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaGame> Get(int id)
        {
            return await MemorabiliaGame.SingleOrDefaultAsync(memorabiliaGame => memorabiliaGame.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaGame>().Update(memorabiliaGame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
