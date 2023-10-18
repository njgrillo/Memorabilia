namespace Memorabilia.Repository.Implementations;

public class CommissionerRepository 
    : DomainRepository<Commissioner>, ICommissionerRepository
{
    public CommissionerRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Commissioner> Commissioner 
        => Items.Include(commissioner => commissioner.Person);

    public override async Task<Commissioner> Get(int id)
        => await Commissioner.SingleOrDefaultAsync(commissioner => commissioner.Id == id);

    public async Task<Commissioner[]> GetAll(int? sportLeagueLevelId = null)
        => !sportLeagueLevelId.HasValue
            ? await Commissioner.ToArrayAsync()
            : await Commissioner.Where(commissioner => commissioner.SportLeagueLevelId == sportLeagueLevelId)
                                .ToArrayAsync();
}
