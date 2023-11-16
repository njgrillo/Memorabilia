namespace Memorabilia.Repository.Implementations;

public class SingleSeasonRecordRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<SingleSeasonRecord>(context, memoryCache), ISingleSeasonRecordRepository
{
    private IQueryable<SingleSeasonRecord> SingleSeasonRecords 
        => Items.Include(record => record.Person);

    public async Task<IEnumerable<SingleSeasonRecord>> GetAll(int sportId)
        => await SingleSeasonRecords.Where(record => record.Person.Sports.Select(sport => sport.SportId).Contains(sportId))
                                    .AsNoTracking()
                                    .ToListAsync();
}
