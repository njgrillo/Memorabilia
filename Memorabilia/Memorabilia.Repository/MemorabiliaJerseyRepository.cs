using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaJerseyRepository : BaseRepository<Domain.Entities.MemorabiliaJersey>, IMemorabiliaJerseyRepository
    {
        private readonly Context _context;

        public MemorabiliaJerseyRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaJersey> MemorabiliaJersey => _context.Set<Domain.Entities.MemorabiliaJersey>();

        public async Task Add(Domain.Entities.MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaJersey);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaJersey>().Remove(memorabiliaJersey);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaJersey> Get(int id)
        {
            return await MemorabiliaJersey.SingleOrDefaultAsync(memorabiliaJersey => memorabiliaJersey.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaJersey memorabiliaJersey, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaJersey>().Update(memorabiliaJersey);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
