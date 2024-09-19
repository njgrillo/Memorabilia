namespace Memorabilia.Repository.Implementations;

public class FranchiseRepository(DomainContext context, IMemoryCache memory)
    : DomainRepository<Franchise>(context, memory), IFranchiseRepository
{
    private IQueryable<Franchise> Franchises
        => Items.Include(franchise => franchise.CareerFranchiseRecords)
                .Include(franchise => franchise.SingleSeasonFranchiseRecords);

    public async Task<PagedResult<Franchise>> GetAll(PageInfo pageInfo)
        => await Franchises.OrderBy(franchise => franchise.Name)
                           .ToPagedResult(pageInfo);
}
