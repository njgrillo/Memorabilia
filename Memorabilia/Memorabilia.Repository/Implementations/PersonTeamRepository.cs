using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class PersonTeamRepository : DomainRepository<PersonTeam>, IPersonTeamRepository
{
    public PersonTeamRepository(DomainContext context) : base(context) { }

    private IQueryable<PersonTeam> PersonTeams => Items.Include(personTeam => personTeam.Person)
                                                       .Include(personTeam => personTeam.Team);

    public async Task<IEnumerable<PersonTeam>> GetAll(int franchiseId)
    {
        return await PersonTeams.Where(personTeam => personTeam.Team.FranchiseId == franchiseId).ToListAsync();
    }
}
