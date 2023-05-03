using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IAutographRepository : IDomainRepository<Autograph>
{
    int[] GetAcquisitionTypeIds(int userId);

    Task<IEnumerable<Autograph>> GetAll(int? memorabiliaId = null, int? userId = null);

    int[] GetColorIds(int userId);

    int[] GetConditionIds(int userId);

    public decimal GetCostTotal(int userId);

    public decimal GetEstimatedValueTotal(int userId);

    int[] GetSpotIds(int userId);

    int[] GetWritingInstrumentIds(int userId);   
}
