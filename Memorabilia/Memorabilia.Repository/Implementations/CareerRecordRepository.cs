namespace Memorabilia.Repository.Implementations;

public class CareerRecordRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<CareerRecord>(context, memoryCache), ICareerRecordRepository
{
    private IQueryable<CareerRecord> CareerRecords 
        => Items.Include(record => record.Person);

    public async Task<IEnumerable<CareerRecord>> GetAll(int sportId)
        => await CareerRecords.Where(record => record.Person.Sports.Select(sport => sport.SportId).Contains(sportId))
                              .AsNoTracking()
                              .ToListAsync();
}
