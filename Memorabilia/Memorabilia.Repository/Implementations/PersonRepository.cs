namespace Memorabilia.Repository.Implementations;

public class PersonRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Person>(context, memoryCache), IPersonRepository
{
    private IQueryable<Person> Person 
        => Items.Include(person => person.Accomplishments)
                .Include(person => person.AllStars)
                .Include(person => person.Awards)
                .Include(person => person.CareerRecords)
                .Include(person => person.CollegeHallOfFames)
                .Include(person => person.CollegeRetiredNumbers)
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
        => await Person.SingleOrDefaultAsync(person => person.Id == id);

    public async Task<Person> Get(string displayName = null, 
                                  string profileName = null, 
                                  string legalName = null)
    {
        var query =
            from people in Context.Person
            where (displayName == null || people.DisplayName == displayName)
               && (profileName == null || people.ProfileName == profileName)
               && (legalName == null || people.LegalName == legalName)
            select new Person(people);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Person>> GetAll(int? sportId = null, 
                                                  int? sportLeagueLevelId = null)
        => await Items.Where(person => (!sportId.HasValue || person.Sports.Any(sport => sport.SportId == sportId.Value))
                                    && (!sportLeagueLevelId.HasValue || person.Teams.Any(team => team.Team.Franchise.SportLeagueLevel.Id == sportLeagueLevelId.Value)))
                      .ToListAsync();

    public async Task<Person[]> GetAll(Dictionary<string, object> parameters)
    {
        _ = parameters.TryGetValue("IsAllStar", out object isAllStar);
        _ = parameters.TryGetValue("IsWorldSeries", out object isWorldSeries);
        _ = parameters.TryGetValue("AwardTypeId", out object awardTypeId);
        _ = parameters.TryGetValue("BeginYear", out object beginYear);
        _ = parameters.TryGetValue("EndYear", out object endYear);
        _ = parameters.TryGetValue("SportId", out object sportId);

        IQueryable<Person> query;

        if (isAllStar != null && (bool)isAllStar)
        {
            query = from person in Context.Person
                    where
                        person.AllStars.Any(allStar => allStar.SportId == (int)sportId
                                                    && ((endYear == null && allStar.Year == (int)beginYear)
                                                        || (endYear != null && allStar.Year >= (int)beginYear))
                                                    && (endYear == null || allStar.Year <= (int)endYear))
                    orderby person.DisplayName
                    select person;

            return await query.ToArrayAsync();
        }

        if (isWorldSeries != null && (bool)isWorldSeries)
        {
            query = from team in Context.Team
                    join personTeam in Context.PersonTeam on team.Id equals personTeam.TeamId
                    join person in Context.Person on personTeam.PersonId equals person.Id
                    where
                        team.Championships.Any(chip => chip.ChampionTypeId == Constant.ChampionType.WorldSeries.Id 
                                                    && chip.Year == (int)beginYear
                                                    && person.Teams.Any(team => team.TeamId == chip.TeamId 
                                                                             && team.BeginYear <= chip.Year
                                                                             && (team.EndYear == null || team.EndYear >= chip.Year)))
                    orderby person.DisplayName
                    select person;

            return await query.ToArrayAsync();
        }

        if (awardTypeId != null)
        {
            query = from person in Context.Person
                    where
                        person.Awards.Any(award => award.AwardTypeId == (int)awardTypeId
                                                && ((endYear == null && award.Year == (int)beginYear) 
                                                   || (endYear != null && award.Year >= (int)beginYear))
                                                && (endYear == null || award.Year <= (int)endYear))
                    orderby person.DisplayName
                    select person;

            return await query.ToArrayAsync();
        }

        return [];
    }

    public async Task<Person[]> GetAll(int teamId, int year)
    {

        IQueryable<Person> query = from person in Context.Person
                                   where person.Teams.Any(team => team.TeamId == teamId
                                                               && team.BeginYear <= year
                                                               && (team.EndYear == null || team.EndYear >= year))
                                   orderby person.DisplayName
                                   select person;

        return await query.ToArrayAsync();
    }

    public async Task<Person[]> GetAllHallOfFamers(int sportLeagueLevelId, int? year)
    {

        IQueryable<Person> query = from person in Context.Person
                                   where person.HallOfFames.Any(hof => hof.SportLeagueLevelId == sportLeagueLevelId
                                                                    && (year == null || hof.InductionYear == year))
                                   orderby person.DisplayName
                                   select person;

        return await query.ToArrayAsync();
    }

    public async Task<Person[]> GetMostRecent()
    {
        var query =
            from person in Context.Person
            where
                person.Occupations.Count != 0 || 
                person.Positions.Count != 0 || 
                person.Sports.Count != 0
            orderby person.Id descending
            select new Person(person);

        return await query.Take(5)
                          .ToArrayAsync();
    }
}