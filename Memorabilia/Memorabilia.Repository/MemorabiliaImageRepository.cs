using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaImageRepository : BaseRepository<MemorabiliaImage>, IMemorabiliaImageRepository
    {
        private readonly MemorabiliaContext _context;

        public MemorabiliaImageRepository(MemorabiliaContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaImage> MemorabiliaImage => _context.Set<MemorabiliaImage>();

        public async Task Add(MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaImage);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaImage>().Remove(memorabiliaImage);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaImage> Get(int id)
        {
            return await MemorabiliaImage.SingleOrDefaultAsync(memorabiliaImage => memorabiliaImage.Id == id).ConfigureAwait(false);
        }

        public async Task<List<MemorabiliaImage>> GetAll(int memorabiliaId)
        {
            return await MemorabiliaImage.Where(memorabiliaImage => memorabiliaImage.MemorabiliaId == memorabiliaId).ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaImage memorabiliaImage, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaImage>().Update(memorabiliaImage);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
