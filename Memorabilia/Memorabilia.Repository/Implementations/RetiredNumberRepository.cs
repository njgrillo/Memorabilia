namespace Memorabilia.Repository.Implementations;

public class RetiredNumberRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<RetiredNumber>(context, memoryCache), IRetiredNumberRepository
{
    private IQueryable<RetiredNumber> RetiredNumbers 
        => Items.Include(retiredNumber => retiredNumber.Franchise)
                .Include(retiredNumber => retiredNumber.Person);

    public async Task<IEnumerable<RetiredNumber>> GetAll(int franchiseId)
        => (await RetiredNumbers.Where(retiredNumber => retiredNumber.FranchiseId == franchiseId)
                                .AsNoTracking()
                                .ToListAsync())
                    .OrderBy(retiredNumber => retiredNumber.Person.DisplayName);
}
