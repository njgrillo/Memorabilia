namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaForSaleRepository
    : IDomainRepository<MemorabiliaForSale>
{
    Task<MemorabiliaForSale[]> GetAll(int[] ids);

    Task<PagedResult<MemorabiliaForSale>> GetAllForSale(int userId,
                                                               PageInfo pageInfo,
                                                               MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<ForSaleSummary> GetSummary(int userId);
}
