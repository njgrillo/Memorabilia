namespace Memorabilia.Repository.Implementations;

public class LeaderRepository 
    : DomainRepository<Leader>, ILeaderRepository
{
    public LeaderRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Leader> Leaders 
        => Items.Include(leader => leader.Person);

    public async Task<IEnumerable<Leader>> GetAll(int leaderTypeId)
        => await Leaders.Where(leader => leader.LeaderTypeId == leaderTypeId)
                        .AsNoTracking()
                        .ToListAsync();
}
