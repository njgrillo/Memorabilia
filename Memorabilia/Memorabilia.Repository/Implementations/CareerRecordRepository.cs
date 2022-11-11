using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class CareerRecordRepository : DomainRepository<CareerRecord>, ICareerRecordRepository
{
    public CareerRecordRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<CareerRecord> CareerRecords => Items.Include(record => record.Person);

    public async Task<IEnumerable<CareerRecord>> GetAll(int sportId)
    {
        return await CareerRecords.Where(record => record.Person.Sports.Select(sport => sport.SportId).Contains(sportId))
                                  .AsNoTracking()
                                  .ToListAsync();
    }
}
