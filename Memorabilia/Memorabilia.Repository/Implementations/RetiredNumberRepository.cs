using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class RetiredNumberRepository : DomainRepository<RetiredNumber>, IRetiredNumberRepository
{
    public RetiredNumberRepository(DomainContext context) : base(context) { }

    private IQueryable<RetiredNumber> RetiredNumbers => Items.Include(retiredNumber => retiredNumber.Franchise)
                                                             .Include(retiredNumber => retiredNumber.Person);

    public async Task<IEnumerable<RetiredNumber>> GetAll(int franchiseId)
    {
        return (await RetiredNumbers.Where(retiredNumber => retiredNumber.FranchiseId == franchiseId)
                                    .AsNoTracking()
                                    .ToListAsync())
                  .OrderBy(retiredNumber => retiredNumber.Person.DisplayName);
    }
}
