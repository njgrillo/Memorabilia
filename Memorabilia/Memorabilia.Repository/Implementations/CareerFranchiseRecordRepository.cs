namespace Memorabilia.Repository.Implementations;

public class CareerFranchiseRecordRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<CareerFranchiseRecord>(context, memoryCache), ICareerFranchiseRecordRepository
{
    private IQueryable<CareerFranchiseRecord> CareerFranchiseRecords
        => Items.Include(record => record.Franchise)
                .Include(record => record.Person);

    public async Task<CareerFranchiseRecord[]> GetAll(int recordTypeId)
        => await CareerFranchiseRecords.Where(careerFranchiseRecord => careerFranchiseRecord.RecordTypeId == recordTypeId)
                                       .AsNoTracking()
                                       .ToArrayAsync();

    public async Task<CareerFranchiseRecord[]> GetAllByFranchise(int franchiseId)
        => await CareerFranchiseRecords.Where(careerFranchiseRecord => careerFranchiseRecord.FranchiseId == franchiseId)
                                       .AsNoTracking()
                                       .ToArrayAsync();
}
