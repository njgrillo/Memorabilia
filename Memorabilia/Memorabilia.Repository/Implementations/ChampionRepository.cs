namespace Memorabilia.Repository.Implementations;

public class ChampionRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Champion>(context, memoryCache), IChampionRepository
{
    private IQueryable<Champion> Champions 
        => Items.Include(champion => champion.Team)
                .Include(champion => champion.Team.Franchise);

    public async Task<IEnumerable<Champion>> GetAll(int championTypeId)
        => (await Champions.Where(champion => champion.ChampionTypeId == championTypeId)
                           .AsNoTracking()
                           .ToListAsync())
                    .OrderByDescending(champion => champion.Year);
}
