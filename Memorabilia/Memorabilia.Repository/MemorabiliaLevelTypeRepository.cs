using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaLevelTypeRepository : BaseRepository<Domain.Entities.MemorabiliaLevelType>, IMemorabiliaLevelTypeRepository
    {
        private readonly Context _context;

        public MemorabiliaLevelTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaLevelType> MemorabiliaLevelType => _context.Set<Domain.Entities.MemorabiliaLevelType>();

        public async Task Add(Domain.Entities.MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaLevelType>().Remove(memorabiliaLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaLevelType> Get(int id)
        {
            return await MemorabiliaLevelType.SingleOrDefaultAsync(memorabiliaLevelType => memorabiliaLevelType.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaLevelType>().Update(memorabiliaLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
