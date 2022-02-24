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
                                                                 .Include(team => team.Conferences)
                                                                 .Include(team => team.Divisions)
                                                                 .Include(team => team.Franchise)
                                                                 .Include(team => team.Leagues);

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

        public async Task<IEnumerable<Domain.Entities.Team>> GetAll(int? franchiseId = null, int? sportLeageLevelId = null)
        {
            if (franchiseId.HasValue)
            {
                return (await Team.Where(team => team.FranchiseId == franchiseId)
                                  .ToListAsync()
                                  .ConfigureAwait(false)).OrderBy(team => team.Name);
            }

            if (sportLeageLevelId.HasValue)
            {
                return (await Team.Where(team => team.Franchise.SportLeagueLevelId == sportLeageLevelId)
                                  .ToListAsync()
                                  .ConfigureAwait(false)).OrderBy(team => team.Franchise.SportLeagueLevelName)
                                                         .ThenBy(team => team.Name);
            }

            return (await Team.ToListAsync()
                              .ConfigureAwait(false)).OrderBy(team => team.Franchise.SportLeagueLevelName)
                                                     .ThenBy(team => team.Name);
        }

        public async Task Update(Domain.Entities.Team team, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Team>().Update(team);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
