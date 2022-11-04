using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class ChampionRepository : DomainRepository<Champion>, IChampionRepository
{
    public ChampionRepository(DomainContext context) : base(context) { }

    private IQueryable<Champion> Champions => Items.Include(champion => champion.Team);

    public async Task<IEnumerable<Champion>> GetAll(int championTypeId)
    {
        return (await Champions.Where(champion => champion.ChampionTypeId == championTypeId).ToListAsync())
                               .OrderByDescending(champion => champion.Year);
    }
}
