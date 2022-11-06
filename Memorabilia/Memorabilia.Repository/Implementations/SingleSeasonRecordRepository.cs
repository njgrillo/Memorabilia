using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class SingleSeasonRecordRepository : DomainRepository<SingleSeasonRecord>, ISingleSeasonRecordRepository
{
    public SingleSeasonRecordRepository(DomainContext context) : base(context) { }

    private IQueryable<SingleSeasonRecord> SingleSeasonRecords => Items.Include(record => record.Person);

    public async Task<IEnumerable<SingleSeasonRecord>> GetAll(int sportId)
    {
        return await SingleSeasonRecords.Where(record => record.Person.Sports.Select(sport => sport.SportId).Contains(sportId))
                                        .AsNoTracking()
                                        .ToListAsync();
    }
}
