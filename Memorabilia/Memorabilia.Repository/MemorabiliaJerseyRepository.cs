using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaJerseyRepository : BaseRepository<MemorabiliaJersey>, IMemorabiliaJerseyRepository
    {
        private readonly Context _context;

        public MemorabiliaJerseyRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaJersey> MemorabiliaJersey => _context.Set<MemorabiliaJersey>();

        public async Task Add(MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaJersey);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaJersey>().Remove(memorabiliaJersey);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaJersey> Get(int id)
        {
            return await MemorabiliaJersey.SingleOrDefaultAsync(memorabiliaJersey => memorabiliaJersey.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaJersey>().Update(memorabiliaJersey);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
