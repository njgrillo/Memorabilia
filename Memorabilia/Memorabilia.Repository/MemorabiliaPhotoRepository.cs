using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaPhotoRepository : BaseRepository<Domain.Entities.MemorabiliaPhoto>, IMemorabiliaPhotoRepository
    {
        private readonly Context _context;

        public MemorabiliaPhotoRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaPhoto> MemorabiliaPhoto => _context.Set<Domain.Entities.MemorabiliaPhoto>();

        public async Task Add(Domain.Entities.MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaPhoto);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaPhoto>().Remove(memorabiliaPhoto);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaPhoto> Get(int id)
        {
            return await MemorabiliaPhoto.SingleOrDefaultAsync(memorabiliaPhoto => memorabiliaPhoto.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaPhoto>().Update(memorabiliaPhoto);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
