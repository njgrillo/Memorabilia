using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBookRepository : BaseRepository<MemorabiliaBook>, IMemorabiliaBookRepository
    {
        private readonly Context _context;

        public MemorabiliaBookRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaBook> MemorabiliaBook => _context.Set<MemorabiliaBook>();

        public async Task Add(MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBook);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBook>().Remove(memorabiliaBook);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaBook> Get(int id)
        {
            return await MemorabiliaBook.SingleOrDefaultAsync(memorabiliaBook => memorabiliaBook.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaBook memorabiliaBook, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaBook>().Update(memorabiliaBook);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
