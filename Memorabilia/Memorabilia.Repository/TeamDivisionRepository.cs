using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class TeamDivisionRepository : BaseRepository<Domain.Entities.TeamDivision>, ITeamDivisionRepository
    {
        private readonly Context _context;

        public TeamDivisionRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.TeamDivision> TeamDivision => _context.Set<Domain.Entities.TeamDivision>()
                                                                                 .Include(teamDivision => teamDivision.Team);

        public async Task Add(Domain.Entities.TeamDivision teamDivision, CancellationToken cancellationToken = default)
        {
            _context.Add(teamDivision);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.TeamDivision teamDivision, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.TeamDivision>().Remove(teamDivision);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.TeamDivision> Get(int id)
        {
            return await TeamDivision.SingleOrDefaultAsync(teamDivision => teamDivision.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.TeamDivision>> GetAll(int? teamId = null)
        {
            return teamId.HasValue 
                ? (await TeamDivision.Where(teamDivision => teamDivision.TeamId == teamId) 
                                     .ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(teamDivision => teamDivision.DivisionName)
                                                            .ThenBy(teamDivision => teamDivision.Team?.Name)
                : (await TeamDivision.ToListAsync()
                                     .ConfigureAwait(false)).OrderBy(teamDivision => teamDivision.DivisionName)
                                                            .ThenBy(teamDivision => teamDivision.Team?.Name);
        }

        public async Task Update(Domain.Entities.TeamDivision teamDivision, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.TeamDivision>().Update(teamDivision);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
