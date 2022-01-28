using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaCommissionerRepository : BaseRepository<Domain.Entities.MemorabiliaCommissioner>, IMemorabiliaCommissionerRepository
    {
        private readonly Context _context;

        public MemorabiliaCommissionerRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaCommissioner> MemorabiliaCommissioner => _context.Set<Domain.Entities.MemorabiliaCommissioner>();

        public async Task Add(Domain.Entities.MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaCommissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaCommissioner>().Remove(memorabiliaCommissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaCommissioner> Get(int id)
        {
            return await MemorabiliaCommissioner.SingleOrDefaultAsync(memorabiliaCommissioner => memorabiliaCommissioner.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaCommissioner>().Update(memorabiliaCommissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
