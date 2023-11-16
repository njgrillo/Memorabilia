namespace Memorabilia.Repository.Implementations;

public class PersonTeamRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<PersonTeam>(context, memoryCache), IPersonTeamRepository
{
    private IQueryable<PersonTeam> PersonTeams 
        => Items.Include(personTeam => personTeam.Person)
                .Include(personTeam => personTeam.Team);

    public async Task<IEnumerable<PersonTeam>> GetAll(int franchiseId)
        => await PersonTeams.Where(personTeam => personTeam.Team.FranchiseId == franchiseId)
                            .ToListAsync();
}
