using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class MemorabiliaTeamRepository : BaseRepository<MemorabiliaTeam>, IMemorabiliaTeamRepository
    {
        private readonly Context _context;

        public MemorabiliaTeamRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<MemorabiliaTeam> MemorabiliaTeam => _context.Set<MemorabiliaTeam>();

        public async Task Add(MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default)
        {
            _context.Add(memorabiliaTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(IEnumerable<MemorabiliaTeam> memorabiliaTeams, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaTeam>().RemoveRange(memorabiliaTeams);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<MemorabiliaTeam> Get(int id)
        {
            return await MemorabiliaTeam.SingleOrDefaultAsync(memorabiliaTeam => memorabiliaTeam.Id == id).ConfigureAwait(false);
        }

        public async Task Update(MemorabiliaTeam memorabiliaTeam, CancellationToken cancellationToken = default)
        {
            _context.Set<MemorabiliaTeam>().Update(memorabiliaTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
