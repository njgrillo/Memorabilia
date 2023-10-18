namespace Memorabilia.Repository.Interfaces;

public interface ISingleSeasonRecordRepository
{
    Task<IEnumerable<SingleSeasonRecord>> GetAll(int sportId);
}
