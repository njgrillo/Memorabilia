using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaOrientationRepository : BaseRepository<Domain.Entities.MemorabiliaOrientation>, IMemorabiliaOrientationRepository
    {
        private readonly Context _context;

        public MemorabiliaOrientationRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaOrientation> MemorabiliaOrientation => _context.Set<Domain.Entities.MemorabiliaOrientation>();

        public async Task Add(Domain.Entities.MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaOrientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaOrientation>().Remove(memorabiliaOrientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaOrientation> Get(int id)
        {
            return await MemorabiliaOrientation.SingleOrDefaultAsync(memorabiliaOrientation => memorabiliaOrientation.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaOrientation memorabiliaOrientation, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaOrientation>().Update(memorabiliaOrientation);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
