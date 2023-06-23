namespace Memorabilia.Repository.Interfaces;

public interface IAutographRepository : IDomainRepository<Entity.Autograph>
{
    int[] GetAcquisitionTypeIds(int userId);

    Task<Entity.Autograph[]> GetAll(int? memorabiliaId = null, int? userId = null);

    Task<Entity.Autograph[]> GetAllBaseballTypes(int itemTypeId,
                                                 int personId,
                                                 int baseballTypeId,
                                                 int? teamId,
                                                 int? year,
                                                 int userId);

    Task<Entity.Autograph[]> GetAllCards(int itemTypeId,
                                         int personId,
                                         int brandId,
                                         int? teamId,
                                         int? year,
                                         int userId);

    Task<Entity.Autograph[]> GetAllHallOfFamers(int itemTypeId,
                                                int personId,
                                                int sportLeagueLevelId,
                                                int? year,
                                                int userId);

    Task<Entity.Autograph[]> GetAllItemTypes(int itemTypeId,
                                             int personId,
                                             bool? multiSignedItem,
                                             int userId);

    Task<Entity.Autograph[]> GetAllTeams(int itemTypeId,
                                         int personId,
                                         int teamId,
                                         int? year,
                                         int userId);

    Task<Entity.Autograph[]> GetAllWorldSeries(int itemTypeId,
                                               int personId,
                                               int teamId,
                                               int? year,
                                               int userId);

    int[] GetColorIds(int userId);

    int[] GetConditionIds(int userId);

    public decimal GetCostTotal(int userId);

    public decimal GetEstimatedValueTotal(int userId);

    int[] GetSpotIds(int userId);

    int[] GetWritingInstrumentIds(int userId);   
}
