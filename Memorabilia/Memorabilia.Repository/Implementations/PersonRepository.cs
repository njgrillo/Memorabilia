using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class PersonRepository : DomainRepository<Person>, IPersonRepository
{
    public PersonRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Person> Person => Items.Include(person => person.Accomplishments)
                                              .Include(person => person.AllStars)
                                              .Include(person => person.Awards)
                                              .Include(person => person.CareerRecords)
                                              .Include(person => person.Colleges)
                                              .Include(person => person.FranchiseHallOfFames)
                                              .Include(person => person.HallOfFames)
                                              .Include(person => person.Leaders)
                                              .Include(person => person.Nicknames)
                                              .Include(person => person.Occupations)
                                              .Include(person => person.RetiredNumbers)
                                              .Include(person => person.Service)
                                              .Include(person => person.SingleSeasonRecords)
                                              .Include(person => person.Sports)
                                              .Include(person => person.Teams)
                                              .Include("Sports.Sport")
                                              .Include("Teams.Team");

    public override async Task<Person> Get(int id)
    {
        return await Person.SingleOrDefaultAsync(person => person.Id == id);
    }

    public async Task<IEnumerable<Person>> GetAll(int? sportId = null, int? sportLeagueLevelId = null)
    {
        return await Items.Where(person => (!sportId.HasValue || person.Teams.Any(team => team.Team.Franchise.SportLeagueLevel.SportId == sportId.Value))
                                        && (!sportLeagueLevelId.HasValue || person.Teams.Any(team => team.Team.Franchise.SportLeagueLevel.Id == sportLeagueLevelId.Value)))
                          .ToListAsync();
    }
}