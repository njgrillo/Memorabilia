using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaBaseballTypeRepository : BaseRepository<Domain.Entities.MemorabiliaBaseballType>, IMemorabiliaBaseballTypeRepository
    {
        private readonly Context _context;

        public MemorabiliaBaseballTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaBaseballType> MemorabiliaBaseballType => _context.Set<Domain.Entities.MemorabiliaBaseballType>();

        public async Task Add(Domain.Entities.MemorabiliaBaseballType memorabiliaBaseballType, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaBaseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaBaseballType memorabiliaBaseballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBaseballType>().Remove(memorabiliaBaseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaBaseballType> Get(int id)
        {
            return await MemorabiliaBaseballType.SingleOrDefaultAsync(memorabiliaBaseballType => memorabiliaBaseballType.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaBaseballType memorabiliaBaseballType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaBaseballType>().Update(memorabiliaBaseballType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
