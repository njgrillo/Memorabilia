using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonTeamRepository : BaseRepository<Domain.Entities.PersonTeam>, IPersonTeamRepository
    {
        private readonly Context _context;

        public PersonTeamRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.PersonTeam> PersonTeam => _context.Set<Domain.Entities.PersonTeam>()
                                                                                        .Include(personTeam => personTeam.Team);

        public async Task Add(Domain.Entities.PersonTeam personTeam, CancellationToken cancellationToken = default)
        {
            _context.Add(personTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.PersonTeam personTeam, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PersonTeam>().Remove(personTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.PersonTeam> Get(int id)
        {
            return await PersonTeam.SingleOrDefaultAsync(personTeam => personTeam.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.PersonTeam>> GetAll(int? personId = null)
        {
            return personId.HasValue
                ? (await PersonTeam.Where(personTeam => personTeam.PersonId == personId)
                                         .ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personTeam => personTeam.Team.Name)
                : (await PersonTeam.ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personTeam => personTeam.Team.Name);
        }

        public async Task Update(Domain.Entities.PersonTeam personTeam, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.PersonTeam>().Update(personTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
