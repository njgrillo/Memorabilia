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

        private IQueryable<Domain.Entities.Team> Team => _context.Set<Domain.Entities.Team>()
                                                                 .Include(team => team.Franchise);

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
            return await Team.SingleOrDefaultAsync(team => team.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Team>> GetAll(int? sportId = null)
        {
            try
            {
                return !sportId.HasValue
                ? (await Team.ToListAsync()
                             .ConfigureAwait(false)).OrderBy(team => team.Franchise.SportName)
                                                    .ThenBy(team => team.Name)
                : (await Team.Where(team => team.Franchise.SportId == sportId)
                             .ToListAsync()
                             .ConfigureAwait(false)).OrderBy(team => team.Franchise.SportName)
                                                    .ThenBy(team => team.Name);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task Update(Domain.Entities.Team team, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Team>().Update(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
