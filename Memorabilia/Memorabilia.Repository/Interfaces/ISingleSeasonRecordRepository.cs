namespace Memorabilia.Repository.Interfaces;

public interface ISingleSeasonRecordRepository : IDomainRepository<SingleSeasonRecord>
{
    Task<IEnumerable<SingleSeasonRecord>> GetAll(int sportId);
}
