namespace Memorabilia.Repository.Interfaces;

public interface IAutographRepository : IDomainRepository<Entity.Autograph>
{
    int[] GetAcquisitionTypeIds(int userId);

    Task<Entity.Autograph[]> GetAll(int? memorabiliaId = null, int? userId = null);

    Task<Entity.Autograph[]> GetAll(Dictionary<string, object> parameters, int userId);

    int[] GetColorIds(int userId);

    int[] GetConditionIds(int userId);

    public decimal GetCostTotal(int userId);

    public decimal GetEstimatedValueTotal(int userId);

    int[] GetSpotIds(int userId);

    int[] GetWritingInstrumentIds(int userId);   
}
