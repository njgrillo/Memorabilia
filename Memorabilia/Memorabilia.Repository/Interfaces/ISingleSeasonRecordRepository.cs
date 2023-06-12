namespace Memorabilia.Repository.Interfaces;

public interface ISingleSeasonRecordRepository
{
    Task<IEnumerable<Entity.SingleSeasonRecord>> GetAll(int sportId);
}
