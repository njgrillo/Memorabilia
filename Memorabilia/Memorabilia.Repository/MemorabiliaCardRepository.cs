using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaCardRepository : BaseRepository<Domain.Entities.MemorabiliaCard>, IMemorabiliaCardRepository
    {
        private readonly Context _context;

        public MemorabiliaCardRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaCard> MemorabiliaCard => _context.Set<Domain.Entities.MemorabiliaCard>();

        public async Task Add(Domain.Entities.MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaCard);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaCard>().Remove(memorabiliaCard);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaCard> Get(int id)
        {
            return await MemorabiliaCard.SingleOrDefaultAsync(memorabiliaCard => memorabiliaCard.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaCard memorabiliaCard, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaCard>().Update(memorabiliaCard);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
