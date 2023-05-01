namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaItemRepository : IDomainRepository<Domain.Entities.Memorabilia>
{
    int[] GetAcquisitionTypeIds(int userId);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId);

    Task<PagedResult<Domain.Entities.Memorabilia>> GetAll(
        int userId,
        PageInfo pageInfo,
        MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId);

    int[] GetBrandIds(int userId);

    int[] GetConditionIds(int userId);

    int[] GetPurchaseTypeIds(int userId);

    int[] GetSizeIds(int userId);

    int[] GetSportIds(int userId);
}
