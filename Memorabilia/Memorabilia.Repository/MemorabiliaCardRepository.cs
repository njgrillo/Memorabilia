using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaCardRepository : BaseRepository<MemorabiliaCard>, IMemorabiliaCardRepository
    {
        private readonly Context _context;

        public MemorabiliaCardRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaCard> MemorabiliaCard => _context.Set<MemorabiliaCard>();

        public async Task Add(MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaCard);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaCard>().Remove(memorabiliaCard);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaCard> Get(int id)
        {
            return await MemorabiliaCard.SingleOrDefaultAsync(memorabiliaCard => memorabiliaCard.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaCard>().Update(memorabiliaCard);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
