using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaTeamRepository : BaseRepository<Domain.Entities.MemorabiliaTeam>, IMemorabiliaTeamRepository
    {
        private readonly Context _context;

        public MemorabiliaTeamRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.MemorabiliaTeam> MemorabiliaTeam => _context.Set<Domain.Entities.MemorabiliaTeam>();

        public async Task Add(Domain.Entities.MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaTeam>().Remove(memorabiliaTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.MemorabiliaTeam> Get(int id)
        {
            return await MemorabiliaTeam.SingleOrDefaultAsync(memorabiliaTeam => memorabiliaTeam.Id == id).ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.MemorabiliaTeam>().Update(memorabiliaTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
