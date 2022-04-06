using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaCommissionerRepository : BaseRepository<MemorabiliaCommissioner>, IMemorabiliaCommissionerRepository
    {
        private readonly Context _context;

        public MemorabiliaCommissionerRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaCommissioner> MemorabiliaCommissioner => _context.Set<MemorabiliaCommissioner>();

        public async Task Add(MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaCommissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaCommissioner>().Remove(memorabiliaCommissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaCommissioner> Get(int id)
        {
            return await MemorabiliaCommissioner.SingleOrDefaultAsync(memorabiliaCommissioner => memorabiliaCommissioner.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaCommissioner memorabiliaCommissioner, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaCommissioner>().Update(memorabiliaCommissioner);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
