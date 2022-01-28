using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class TeamRepository : BaseRepository<Domain.Entities.Team>, ITeamRepository
    {
        private readonly Context _context;

        public TeamRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Team> Team => _context.Set<Domain.Entities.Team>();

        public async Task Add(Domain.Entities.Team team, CancellationToken cancellationToken = default)
        {
            _context.Add(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Team team, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Team>().Remove(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Team> Get(int id)
        {
            return await Team.SingleOrDefaultAsync(user => user.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Team>> GetAll()
        {
            return await Team.ToListAsync().ConfigureAwait(false);
        }

        public async Task Update(Domain.Entities.Team team, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Team>().Update(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
