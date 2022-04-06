using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaGameRepository : BaseRepository<MemorabiliaGame>, IMemorabiliaGameRepository
    {
        private readonly Context _context;

        public MemorabiliaGameRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaGame> MemorabiliaGame => _context.Set<MemorabiliaGame>();

        public async Task Add(MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaGame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaGame>().Remove(memorabiliaGame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaGame> Get(int id)
        {
            return await MemorabiliaGame.SingleOrDefaultAsync(memorabiliaGame => memorabiliaGame.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaGame memorabiliaGame, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaGame>().Update(memorabiliaGame);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
