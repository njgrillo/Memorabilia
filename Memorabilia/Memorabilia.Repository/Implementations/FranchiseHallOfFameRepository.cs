namespace Memorabilia.Repository.Implementations;

public class FranchiseHallOfFameRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<FranchiseHallOfFame>(context, memoryCache), IFranchiseHallOfFameRepository
{
    private IQueryable<FranchiseHallOfFame> FranchiseHallOfFames 
        => Items.Include(franchiseHallOfFame => franchiseHallOfFame.Franchise)
                .Include(franchiseHallOfFame => franchiseHallOfFame.Person);

    public async Task<IEnumerable<FranchiseHallOfFame>> GetAll(int franchiseId)
        => (await FranchiseHallOfFames.Where(franchiseHallOfFame => franchiseHallOfFame.FranchiseId == franchiseId)
                                      .AsNoTracking()
                                      .ToListAsync())
                  .OrderByDescending(franchiseHallOfFame => franchiseHallOfFame.Person.DisplayName);
}
