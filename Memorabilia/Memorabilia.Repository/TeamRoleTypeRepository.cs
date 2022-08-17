using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class TeamRoleTypeRepository : BaseRepository<TeamRoleType>, ITeamRoleTypeRepository
    {
        private readonly DomainContext _context;

        public TeamRoleTypeRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<TeamRoleType> TeamRoleType => _context.Set<TeamRoleType>();

        public async Task Add(TeamRoleType teamRoleType, CancellationToken cancellationToken = default)
        {
            _context.Add(teamRoleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(TeamRoleType teamRoleType, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamRoleType>().Remove(teamRoleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<TeamRoleType> Get(int id)
        {
            return await TeamRoleType.SingleOrDefaultAsync(teamRoleType => teamRoleType.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TeamRoleType>> GetAll()
        {
            return (await TeamRoleType.ToListAsync().ConfigureAwait(false)).OrderBy(TeamRoleType => TeamRoleType.Name);
        }

        public async Task Update(TeamRoleType teamRoleType, CancellationToken cancellationToken = default)
        {
            _context.Set<TeamRoleType>().Update(teamRoleType);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
