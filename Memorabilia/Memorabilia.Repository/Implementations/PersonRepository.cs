namespace Memorabilia.Repository.Implementations;

public class PersonRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Person>(context, memoryCache), IPersonRepository
{
    private IQueryable<Person> Person 
        => Items.Include(person => person.Accomplishments)
                .Include(person => person.AllStars)
                .Include(person => person.Awards)
                .Include(person => person.CareerFranchiseRecords)
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
                .Include(person => person.SingleSeasonFranchiseRecords)
                .Include(person => person.SingleSeasonRecords)
                .Include(person => person.Sports)
                .Include(person => person.Teams)
                .Include("Sports.Sport")
                .Include("Teams.Team");

    public override async Task<Person> Get(int id)
        => await Person.SingleOrDefaultAsync(person => person.Id == id);

    public async Task<IEnumerable<Person>> GetAll(
        int? sportId = null, 
        int? sportLeagueLevelId = null,
        int? userId = null,
        bool? filterOutDeceased = null
        )
        => await Items.Where(person => 
                (!person.IsUserAdded || (userId != null && person.UserAddedId == userId)) &&
                ((!filterOutDeceased ?? true) || (!person.DeathDate.HasValue && (!person.BirthDate.HasValue || person.BirthDate.Value.Year > 1907))) &&
                (!sportId.HasValue || person.Sports.Any(sport => sport.SportId == sportId.Value)) &&
                (!sportLeagueLevelId.HasValue || person.Teams.Any(team => team.Team.Franchise.SportLeagueLevel.Id == sportLeagueLevelId.Value)))
                      .ToListAsync();

    public async Task<Person[]> GetAll(Dictionary<string, object> parameters, int userId)
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
                        (!person.IsUserAdded || person.UserAddedId == userId) &&
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

    public async Task<Person[]> GetAll(int teamId, int year, int userId)
    {

        IQueryable<Person> query = from person in Context.Person
                                   where (!person.IsUserAdded || person.UserAddedId == userId) &&
                                          person.Teams.Any(team => team.TeamId == teamId
                                                               && team.BeginYear <= year
                                                               && (team.EndYear == null || team.EndYear >= year))
                                   orderby person.DisplayName
                                   select person;

        return await query.ToArrayAsync();
    }

    public async Task<Person[]> GetAll(int[] ids)
    {
        IQueryable<Person> query = from person in Context.Person
                                   where ids.Contains(person.Id) 
                                   orderby person.DisplayName
                                   select person;

        return await query.ToArrayAsync();
    }

    public async Task<PagedResult<Person>> GetAll(
        PageInfo pageInfo,
        int? sportId = null,
        string filter = null,
        bool? isToday = null,
        DateTime? birthMonthDay = null,
        int? birthMonth = null,
        int? birthYear = null,
        DateTime? birthDate = null,
        DateTime? deathMonthDay = null,
        int? deathMonth = null,
        int? deathYear = null,
        DateTime? deathDate = null
        )
    {
        bool isDate = DateTime.TryParse(filter, out DateTime searchDate);

        filter = $"%{filter}%";

        var query =
            from person in Context.Person
            where !person.IsUserAdded &&
                  (person.BirthDate != null || person.DeathDate != null) &&
                  ((!isToday ?? false) || person.BirthDate.Value.Month == DateTime.UtcNow.Month && person.BirthDate.Value.Day == DateTime.UtcNow.Day) &&
                  (birthMonthDay == null || (person.BirthDate != null && person.BirthDate.Value.Month == birthMonthDay.Value.Month && person.BirthDate.Value.Day == birthMonthDay.Value.Day)) &&
                  (deathMonthDay == null || (person.DeathDate != null && person.DeathDate.Value.Month == deathMonthDay.Value.Month && person.DeathDate.Value.Day == deathMonthDay.Value.Day)) &&
                  (birthMonth == null || (person.BirthDate != null && person.BirthDate.Value.Month == birthMonth)) &&                  
                  (deathMonth == null || (person.DeathDate != null && person.DeathDate.Value.Month == deathMonth)) &&
                  (birthYear == null || (person.BirthDate != null && person.BirthDate.Value.Year == birthYear)) &&
                  (deathYear == null || (person.DeathDate != null && person.DeathDate.Value.Year == deathYear)) &&
                  (birthDate == null || (person.BirthDate != null && person.BirthDate == birthDate)) &&
                  (deathDate == null || (person.DeathDate != null && person.DeathDate == deathDate)) &&
                  (sportId == null ||
                   (person.Sports.Count > 0 &&
                    person.Sports.Any(x => x.SportId == sportId)
                   )
                  ) &&
                  (filter.IsNullOrEmpty() ||
                   (isDate && (person.BirthDate == searchDate || person.DeathDate == searchDate)) ||
                   EF.Functions.Like(person.FirstName, filter) ||
                   EF.Functions.Like(person.LastName, filter) ||
                   EF.Functions.Like(person.LegalName, filter) ||
                   EF.Functions.Like(person.MiddleName, filter)
                  )
            orderby person.BirthDate
            select person;

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<Person[]> GetAllHallOfFamers(
        int sportLeagueLevelId, 
        int? year
        )
    {

        IQueryable<Person> query = from person in Context.Person
                                   where person.HallOfFames.Any(hof => hof.SportLeagueLevelId == sportLeagueLevelId
                                                                    && (year == null || hof.InductionYear == year))
                                   orderby person.DisplayName
                                   select person;

        return await query.ToArrayAsync();
    }

    public async Task<PagedResult<Person>> GetAllNicknames(
        PageInfo pageInfo, 
        int? sportId = null,
        string filter = null
        )
    {
        filter = $"%{filter}%";

        var query =
            from person in Context.Person
            where !person.IsUserAdded &&
                  person.Nicknames.Count > 0 && 
                  (filter.IsNullOrEmpty() ||
                   EF.Functions.Like(person.FirstName, filter) ||
                   EF.Functions.Like(person.LastName, filter) ||
                   EF.Functions.Like(person.LegalName, filter) ||
                   EF.Functions.Like(person.MiddleName, filter) ||
                   person.Nicknames.Any(personNickname => EF.Functions.Like(personNickname.Nickname, filter))
                   ) &&
                  (sportId == null ||
                   (person.Sports.Count > 0 &&
                    person.Sports.Any(x => x.SportId == sportId)
                   )
                  )
            orderby person.ProfileName
            select person;

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<Person[]> GetMostRecent()
    {
        var query =
            from person in Context.Person
            where
                !person.IsUserAdded &&
                person.Occupations.Count != 0 || 
                person.Positions.Count != 0 || 
                person.Sports.Count != 0
            orderby person.Id descending
            select new Person(person);

        return await query.Take(10)
                          .ToArrayAsync();
    }
}