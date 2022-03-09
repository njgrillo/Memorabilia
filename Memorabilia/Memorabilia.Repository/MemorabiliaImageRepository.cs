using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaImageRepository : BaseRepository<Domain.Entities.MemorabiliaImage>, IMemorabiliaImageRepository
    {
        private readonly Context _context;

        public MemorabiliaImageRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaImage> MemorabiliaImage => _context.Set<Domain.Entities.MemorabiliaImage>();

        public async Task Add(Domain.Entities.MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaImage);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaImage>().Remove(memorabiliaImage);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaImage> Get(int id)
        {
            return await MemorabiliaImage.SingleOrDefaultAsync(memorabiliaImage => memorabiliaImage.Id == id).ConfigureAwait(false);
        }

        public async Task<List<Domain.Entities.MemorabiliaImage>> GetAll(int memorabiliaId)
        {
            return await MemorabiliaImage.Where(memorabiliaImage => memorabiliaImage.MemorabiliaId == memorabiliaId).ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaImage>().Update(memorabiliaImage);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
