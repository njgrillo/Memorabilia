namespace Memorabilia.Repository.Implementations;

public class LeaderRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Leader>(context, memoryCache), ILeaderRepository
{
    private IQueryable<Leader> Leaders 
        => Items.Include(leader => leader.Person);

    public async Task<IEnumerable<Leader>> GetAll(int leaderTypeId)
        => await Leaders.Where(leader => leader.LeaderTypeId == leaderTypeId)
                        .AsNoTracking()
                        .ToListAsync();
}
