namespace Memorabilia.Repository.Implementations;

public class RetiredNumberRepository 
    : DomainRepository<Entity.RetiredNumber>, IRetiredNumberRepository
{
    public RetiredNumberRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.RetiredNumber> RetiredNumbers 
        => Items.Include(retiredNumber => retiredNumber.Franchise)
                .Include(retiredNumber => retiredNumber.Person);

    public async Task<IEnumerable<Entity.RetiredNumber>> GetAll(int franchiseId)
        => (await RetiredNumbers.Where(retiredNumber => retiredNumber.FranchiseId == franchiseId)
                                .AsNoTracking()
                                .ToListAsync())
                    .OrderBy(retiredNumber => retiredNumber.Person.DisplayName);
}
