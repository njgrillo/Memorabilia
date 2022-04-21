using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class LeaderTypeRepository : BaseRepository<LeaderType>, ILeaderTypeRepository
    {
        private readonly DomainContext _context;

        public LeaderTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<LeaderType> LeaderType => _context.Set<LeaderType>();

        public async Task Add(LeaderType leaderType, CancellationToken cancellationToken = default)
        {
            _context.Add(leaderType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(LeaderType leaderType, CancellationToken cancellationToken = default)
        {
            _context.Set<LeaderType>().Remove(leaderType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<LeaderType> Get(int id)
        {
            return await LeaderType.SingleOrDefaultAsync(LeaderType => LeaderType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeaderType>> GetAll()
        {
            return (await LeaderType.ToListAsync().ConfigureAwait(false)).OrderBy(LeaderType => LeaderType.Name);
        }

        public async Task Update(LeaderType leaderType, CancellationToken cancellationToken = default)
        {
            _context.Set<LeaderType>().Update(leaderType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
