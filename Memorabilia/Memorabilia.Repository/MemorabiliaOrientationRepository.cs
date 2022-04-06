using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaOrientationRepository : BaseRepository<MemorabiliaOrientation>, IMemorabiliaOrientationRepository
    {
        private readonly Context _context;

        public MemorabiliaOrientationRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaOrientation> MemorabiliaOrientation => _context.Set<MemorabiliaOrientation>();

        public async Task Add(MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaOrientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaOrientation>().Remove(memorabiliaOrientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaOrientation> Get(int id)
        {
            return await MemorabiliaOrientation.SingleOrDefaultAsync(memorabiliaOrientation => memorabiliaOrientation.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaOrientation>().Update(memorabiliaOrientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
