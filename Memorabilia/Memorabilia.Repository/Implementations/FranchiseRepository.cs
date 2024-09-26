namespace Memorabilia.Repository.Implementations;

public class FranchiseRepository(DomainContext context, IMemoryCache memory)
    : DomainRepository<Franchise>(context, memory), IFranchiseRepository
{
    public async Task<PagedResult<Franchise>> GetAll(PageInfo pageInfo, string filter = null)
    {
        filter = $"%{filter}%";

        var query =
                from franchise in Context.Franchise
                where filter.IsNullOrEmpty()
                    || EF.Functions.Like(franchise.Name, filter)
                    || EF.Functions.Like(franchise.SportLeagueLevel.Abbreviation, filter)
                    || EF.Functions.Like(franchise.SportLeagueLevel.Name, filter)
                orderby franchise.Name
                select franchise;

        return await query.ToPagedResult(pageInfo);
    }
}
