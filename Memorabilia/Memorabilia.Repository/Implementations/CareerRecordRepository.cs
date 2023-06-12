namespace Memorabilia.Repository.Implementations;

public class CareerRecordRepository 
    : DomainRepository<Entity.CareerRecord>, ICareerRecordRepository
{
    public CareerRecordRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.CareerRecord> CareerRecords 
        => Items.Include(record => record.Person);

    public async Task<IEnumerable<Entity.CareerRecord>> GetAll(int sportId)
        => await CareerRecords.Where(record => record.Person.Sports.Select(sport => sport.SportId).Contains(sportId))
                              .AsNoTracking()
                              .ToListAsync();
}
