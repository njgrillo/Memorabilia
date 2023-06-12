namespace Memorabilia.Repository.Interfaces;

public interface ICareerRecordRepository
{
    Task<IEnumerable<Entity.CareerRecord>> GetAll(int sportId);
}
