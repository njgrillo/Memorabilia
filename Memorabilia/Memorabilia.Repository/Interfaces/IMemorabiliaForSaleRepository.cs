namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaForSaleRepository
    : IDomainRepository<Entity.MemorabiliaForSale>
{
    Task<Entity.MemorabiliaForSale[]> GetAll(int[] ids);

    Task<PagedResult<Entity.MemorabiliaForSale>> GetAllForSale(int userId,
                                                               PageInfo pageInfo,
                                                               MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);
}
