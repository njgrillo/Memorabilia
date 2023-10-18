namespace Memorabilia.Repository.Interfaces;

public interface ICareerRecordRepository
{
    Task<IEnumerable<CareerRecord>> GetAll(int sportId);
}
