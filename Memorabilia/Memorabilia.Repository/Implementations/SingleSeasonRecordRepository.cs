namespace Memorabilia.Repository.Implementations;

public class SingleSeasonRecordRepository 
    : DomainRepository<Entity.SingleSeasonRecord>, ISingleSeasonRecordRepository
{
    public SingleSeasonRecordRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.SingleSeasonRecord> SingleSeasonRecords 
        => Items.Include(record => record.Person);

    public async Task<IEnumerable<Entity.SingleSeasonRecord>> GetAll(int sportId)
        => await SingleSeasonRecords.Where(record => record.Person.Sports.Select(sport => sport.SportId).Contains(sportId))
                                    .AsNoTracking()
                                    .ToListAsync();
}
