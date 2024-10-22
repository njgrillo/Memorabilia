namespace Memorabilia.Repository.Implementations;

public class LeaderRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Leader>(context, memoryCache), ILeaderRepository
{
    private IQueryable<Leader> Leaders 
        => Items.Include(leader => leader.Person)
                .ThenInclude(person => person.Sports);

    public async Task<IEnumerable<Leader>> GetAll(int leaderTypeId)
        => await Leaders.Where(leader => leader.LeaderTypeId == leaderTypeId)
                        .AsNoTracking()
                        .ToListAsync();

    public async Task<IEnumerable<Leader>> GetAll(int sportId, int year)
        => await Leaders.Where(leader => leader.Person.Sports.Select(sport => sport.SportId).Contains(sportId) &&
                                         leader.Year == year)
                        .AsNoTracking()
                        .ToListAsync();
}
