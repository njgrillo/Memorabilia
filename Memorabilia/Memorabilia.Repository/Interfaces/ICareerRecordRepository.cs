namespace Memorabilia.Repository.Interfaces;

public interface ICareerRecordRepository : IDomainRepository<CareerRecord>
{
    Task<IEnumerable<CareerRecord>> GetAll(int sportId);
}
