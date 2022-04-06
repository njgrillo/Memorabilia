using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaLevelTypeRepository : BaseRepository<MemorabiliaLevelType>, IMemorabiliaLevelTypeRepository
    {
        private readonly Context _context;

        public MemorabiliaLevelTypeRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaLevelType> MemorabiliaLevelType => _context.Set<MemorabiliaLevelType>();

        public async Task Add(MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaLevelType>().Remove(memorabiliaLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaLevelType> Get(int id)
        {
            return await MemorabiliaLevelType.SingleOrDefaultAsync(memorabiliaLevelType => memorabiliaLevelType.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaLevelType memorabiliaLevelType, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaLevelType>().Update(memorabiliaLevelType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
