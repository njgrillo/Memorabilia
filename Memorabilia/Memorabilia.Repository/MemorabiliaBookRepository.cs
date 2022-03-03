using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBookRepository : BaseRepository<Domain.Entities.MemorabiliaBook>, IMemorabiliaBookRepository
    {
        private readonly Context _context;

        public MemorabiliaBookRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaBook> MemorabiliaBook => _context.Set<Domain.Entities.MemorabiliaBook>();

        public async Task Add(Domain.Entities.MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBook);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBook>().Remove(memorabiliaBook);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaBook> Get(int id)
        {
            return await MemorabiliaBook.SingleOrDefaultAsync(memorabiliaBook => memorabiliaBook.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBook>().Update(memorabiliaBook);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
