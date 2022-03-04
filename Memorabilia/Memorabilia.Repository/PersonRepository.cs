using Memorabilia.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonRepository : BaseRepository<Domain.Entities.Person>, IPersonRepository
    {
        private readonly Context _context;

        public PersonRepository(Context context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Domain.Entities.Person> Person => _context.Set<Domain.Entities.Person>()
                                                                     .Include(person => person.HallOfFames)
                                                                     .Include(person => person.Occupations)
                                                                     .Include(person => person.Teams)
                                                                     .Include("Teams.Team");

        public async Task Add(Domain.Entities.Person person, CancellationToken cancellationToken = default)
        {
            _context.Add(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Domain.Entities.Person person, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Person>().Remove(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Domain.Entities.Person> Get(int id)
        {
            return await Person.SingleOrDefaultAsync(person => person.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.Entities.Person>> GetAll(int? sportId = null)
        {
            return sportId.HasValue 
                ? (await Person.Where(person => person.Teams.Any(team => team.Team.Franchise.SportLeagueLevel.SportId == sportId.Value))
                               .ToListAsync()
                               .ConfigureAwait(false))
                               .OrderBy(person => person.DisplayName)
                : (await Person.ToListAsync().ConfigureAwait(false)).OrderBy(person => person.DisplayName);
        }

        public async Task Update(Domain.Entities.Person person, CancellationToken cancellationToken = default)
        {
            _context.Set<Domain.Entities.Person>().Update(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}