using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ChampionRepository : DomainRepository<Champion>, IChampionRepository
{
    public ChampionRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Champion> Champions => Items.Include(champion => champion.Team)
                                                   .Include(champion => champion.Team.Franchise);

    public async Task<IEnumerable<Champion>> GetAll(int championTypeId)
    {
        return (await Champions.Where(champion => champion.ChampionTypeId == championTypeId)
                               .AsNoTracking()
                               .ToListAsync())
                      .OrderByDescending(champion => champion.Year);
    }
}
