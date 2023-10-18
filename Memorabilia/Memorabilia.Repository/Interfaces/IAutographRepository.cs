namespace Memorabilia.Repository.Interfaces;

public interface IAutographRepository : IDomainRepository<Autograph>
{
    int[] GetAcquisitionTypeIds(int userId);

    Task<Autograph[]> GetAll(int? memorabiliaId = null, int? userId = null);

    Task<Autograph[]> GetAllBaseballTypes(int itemTypeId,
                                                 int personId,
                                                 int baseballTypeId,
                                                 int? teamId,
                                                 int? year,
                                                 int userId);

    Task<Autograph[]> GetAllByPerson(int personId, int userId);

    Task<Autograph[]> GetAllCards(int itemTypeId,
                                         int personId,
                                         int brandId,
                                         int? teamId,
                                         int? year,
                                         int userId);

    Task<Autograph[]> GetAllHallOfFamers(int itemTypeId,
                                                int personId,
                                                int sportLeagueLevelId,
                                                int? year,
                                                int userId);

    Task<Autograph[]> GetAllItemTypes(int itemTypeId,
                                             int personId,
                                             bool? multiSignedItem,
                                             int userId);

    Task<Autograph[]> GetAllTeams(int itemTypeId,
                                         int personId,
                                         int teamId,
                                         int? year,
                                         int userId);

    Task<Autograph[]> GetAllWorldSeries(int itemTypeId,
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
