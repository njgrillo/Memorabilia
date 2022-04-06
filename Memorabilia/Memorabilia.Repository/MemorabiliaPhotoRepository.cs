using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaPhotoRepository : BaseRepository<MemorabiliaPhoto>, IMemorabiliaPhotoRepository
    {
        private readonly Context _context;

        public MemorabiliaPhotoRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaPhoto> MemorabiliaPhoto => _context.Set<MemorabiliaPhoto>();

        public async Task Add(MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaPhoto);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaPhoto>().Remove(memorabiliaPhoto);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaPhoto> Get(int id)
        {
            return await MemorabiliaPhoto.SingleOrDefaultAsync(memorabiliaPhoto => memorabiliaPhoto.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaPhoto memorabiliaPhoto, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaPhoto>().Update(memorabiliaPhoto);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
