namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaItemRepository : IDomainRepository<Domain.Entities.Memorabilia>
{
    int[] GetAcquisitionTypeIds(int userId);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId);

    Task<PagedResult<Domain.Entities.Memorabilia>> GetAll(
        int userId,
        PageInfo pageInfo,
        MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<Domain.Entities.Memorabilia[]> GetAll(Dictionary<string, object> parameters);

    Task<PagedResult<Domain.Entities.Memorabilia>> GetAllByCollection(
        int collectionId,
        PageInfo pageInfo,
        MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId);

    int[] GetBrandIds(int userId);

    int[] GetConditionIds(int userId);

    decimal GetCostTotal(int userId);

    decimal GetEstimatedValueTotal(int userId); 

    int[] GetFranchiseIds(int userId);

    int[] GetItemTypeIds(int userId);

    int[] GetPurchaseTypeIds(int userId);

    int[] GetSizeIds(int userId);

    int[] GetSportIds(int userId);

    int[] GetSportLeagueLevelIds(int userId);
}
