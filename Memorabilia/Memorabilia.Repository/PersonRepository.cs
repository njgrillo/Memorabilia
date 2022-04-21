using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Memorabilia.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly DomainContext _context;

        public PersonRepository(DomainContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<Person> Person => _context.Set<Person>()
                                                     .Include(person => person.Accomplishments)
                                                     .Include(person => person.AllStars)
                                                     .Include(person => person.Awards)
                                                     .Include(person => person.CareerRecords)
                                                     .Include(person => person.Colleges)
                                                     .Include(person => person.FranchiseHallOfFames)
                                                     .Include(person => person.HallOfFames)
                                                     .Include(person => person.Leaders)
                                                     .Include(person => person.Occupations)
                                                     .Include(person => person.RetiredNumbers)
                                                     .Include(person => person.Service)
                                                     .Include(person => person.SingleSeasonRecords)
                                                     .Include(person => person.Teams)
                                                     .Include("Teams.Team");

        public async Task Add(Person person, CancellationToken cancellationToken = default)
        {
            _context.Add(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task Delete(Person person, CancellationToken cancellationToken = default)
        {
            _context.Set<Person>().Remove(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Person> Get(int id)
        {
            return await Person.SingleOrDefaultAsync(person => person.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Person>> GetAll(int? sportId = null)
        {
            return sportId.HasValue 
                ? (await Person.Where(person => person.Teams.Any(team => team.Team.Franchise.SportLeagueLevel.SportId == sportId.Value))
                               .ToListAsync()
                               .ConfigureAwait(false))
                               .OrderBy(person => person.DisplayName)
                : (await Person.ToListAsync().ConfigureAwait(false)).OrderBy(person => person.DisplayName);
        }

        public async Task Update(Person person, CancellationToken cancellationToken = default)
        {
            _context.Set<Person>().Update(person);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}