namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaItemRepository 
    : IDomainRepository<Entity.Memorabilia>
{
    int[] GetAcquisitionTypeIds(int userId);

    Task<Entity.Memorabilia[]> GetAll(int userId);

    Task<Entity.Memorabilia[]> GetAll(int[] ids);

    Task<PagedResult<Entity.Memorabilia>> GetAll(int userId,
                                                 PageInfo pageInfo,
                                                 MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<PagedResult<Entity.Memorabilia>> GetAllByCollection(int collectionId,
                                                             PageInfo pageInfo,
                                                             MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<Entity.Memorabilia[]> GetAllForHelmetProject(int itemTypeId,
                                                      int? teamId,
                                                      int? typeId,
                                                      int? sizeId,
                                                      int? finishId,
                                                      int userId);

    Task<Entity.Memorabilia[]> GetAllForTeamProject(int itemTypeId,
                                                    int? teamId,
                                                    int? teamYear,
                                                    int userId);

    Task<PagedResult<Entity.Memorabilia>> GetAllForTrade(int userId,
                                                         PageInfo pageInfo,
                                                         MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<PagedResult<Entity.Memorabilia>> GetAllHistory(int memorabiliaId, PageInfo pageInfo);

    Task<PagedResult<Entity.Memorabilia>> GetAllPurchased(int userId, 
                                                          PageInfo pageInfo,
                                                          MemorabiliaSearchCriteria memorabiliaSearchCriteria = null);

    Task<Entity.Memorabilia[]> GetAllUnsigned(int userId);

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

    Task<bool> HasItemsForSale(int userId);

    Task<bool> HasItemsForTrade(int userId);
}
