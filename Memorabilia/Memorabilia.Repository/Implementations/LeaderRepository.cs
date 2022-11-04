using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class LeaderRepository : DomainRepository<Leader>, ILeaderRepository
{
    public LeaderRepository(DomainContext context) : base(context) { }

    private IQueryable<Leader> Leaders => Items.Include(leader => leader.Person);

    public async Task<IEnumerable<Leader>> GetAll(int leaderTypeId)
    {
        return await Leaders.Where(leader => leader.LeaderTypeId == leaderTypeId).ToListAsync();
    }
}
