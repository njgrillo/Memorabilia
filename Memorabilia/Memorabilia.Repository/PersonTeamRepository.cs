using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonTeamRepository : BaseRepository<PersonTeam>, IPersonTeamRepository
    {
        private readonly DomainContext _context;

        public PersonTeamRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<PersonTeam> PersonTeam => _context.Set<PersonTeam>()
                                                             .Include(personTeam => personTeam.Team);

        public async Task Add(PersonTeam personTeam, CancellationToken cancellationToken = default)
        {
            _context.Add(personTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(PersonTeam personTeam, CancellationToken cancellationToken = default)
        {
            _context.Set<PersonTeam>().Remove(personTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PersonTeam> Get(int id)
        {
            return await PersonTeam.SingleOrDefaultAsync(personTeam => personTeam.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<PersonTeam>> GetAll(int? personId = null)
        {
            return personId.HasValue
                ? (await PersonTeam.Where(personTeam => personTeam.PersonId == personId)
                                         .ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personTeam => personTeam.Team.Name)
                : (await PersonTeam.ToListAsync()
                                         .ConfigureAwait(false)).OrderBy(personTeam => personTeam.Team.Name);
        }

        public async Task Update(PersonTeam personTeam, CancellationToken cancellationToken = default)
        {
            _context.Set<PersonTeam>().Update(personTeam);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
