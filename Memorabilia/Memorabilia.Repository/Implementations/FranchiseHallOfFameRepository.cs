using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class FranchiseHallOfFameRepository : DomainRepository<FranchiseHallOfFame>, IFranchiseHallOfFameRepository
{
    public FranchiseHallOfFameRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<FranchiseHallOfFame> FranchiseHallOfFames => Items.Include(franchiseHallOfFame => franchiseHallOfFame.Franchise)
                                                                         .Include(franchiseHallOfFame => franchiseHallOfFame.Person);

    public async Task<IEnumerable<FranchiseHallOfFame>> GetAll(int franchiseId)
    {
        return (await FranchiseHallOfFames.Where(franchiseHallOfFame => franchiseHallOfFame.FranchiseId == franchiseId)
                                          .AsNoTracking()
                                          .ToListAsync())
                      .OrderByDescending(franchiseHallOfFame => franchiseHallOfFame.Person.DisplayName);
    }
}
