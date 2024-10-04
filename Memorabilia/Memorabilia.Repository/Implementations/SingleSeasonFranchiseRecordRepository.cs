namespace Memorabilia.Repository.Implementations;

public class SingleSeasonFranchiseRecordRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<SingleSeasonFranchiseRecord>(context, memoryCache), ISingleSeasonFranchiseRecordRepository
{
    private IQueryable<SingleSeasonFranchiseRecord> SingleSeasonFranchiseRecords
        => Items.Include(singleSeasonFranchiseRecord => singleSeasonFranchiseRecord.Franchise)
                .Include(singleSeasonFranchiseRecord => singleSeasonFranchiseRecord.Person);

    public async Task<SingleSeasonFranchiseRecord[]> GetAll(int sportId)
        => await SingleSeasonFranchiseRecords.Where(singleSeasonFranchiseRecord => singleSeasonFranchiseRecord.Person.Sports.Select(sport => sport.SportId).Contains(sportId))
                                             .AsNoTracking()
                                             .ToArrayAsync();

    public async Task<SingleSeasonFranchiseRecord[]> GetAllByFranchise(int franchiseId)
        => await SingleSeasonFranchiseRecords.Where(singleSeasonFranchiseRecord => singleSeasonFranchiseRecord.FranchiseId == franchiseId)
                                             .AsNoTracking()
                                             .ToArrayAsync();
}
