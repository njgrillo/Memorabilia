namespace Memorabilia.Repository.Implementations;

public class PersonTeamRepository 
    : DomainRepository<Entity.PersonTeam>, IPersonTeamRepository
{
    public PersonTeamRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.PersonTeam> PersonTeams 
        => Items.Include(personTeam => personTeam.Person)
                .Include(personTeam => personTeam.Team);

    public async Task<IEnumerable<Entity.PersonTeam>> GetAll(int franchiseId)
        => await PersonTeams.Where(personTeam => personTeam.Team.FranchiseId == franchiseId)
                            .ToListAsync();
}
