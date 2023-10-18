namespace Memorabilia.Repository.Implementations;

public class PersonTeamRepository 
    : DomainRepository<PersonTeam>, IPersonTeamRepository
{
    public PersonTeamRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<PersonTeam> PersonTeams 
        => Items.Include(personTeam => personTeam.Person)
                .Include(personTeam => personTeam.Team);

    public async Task<IEnumerable<PersonTeam>> GetAll(int franchiseId)
        => await PersonTeams.Where(personTeam => personTeam.Team.FranchiseId == franchiseId)
                            .ToListAsync();
}
