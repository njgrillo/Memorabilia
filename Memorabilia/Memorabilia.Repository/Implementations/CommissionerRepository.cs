using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class CommissionerRepository : DomainRepository<Commissioner>, ICommissionerRepository
{
    public CommissionerRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Commissioner> Commissioner => Items.Include(commissioner => commissioner.Person);

    public override async Task<Commissioner> Get(int id)
    {
        return await Commissioner.SingleOrDefaultAsync(commissioner => commissioner.Id == id);
    }

    public async Task<IEnumerable<Commissioner>> GetAll(int? sportLeagueLevelId = null)
    {
        return !sportLeagueLevelId.HasValue
            ? await Commissioner.ToListAsync()
            : await Commissioner.Where(commissioner => commissioner.SportLeagueLevelId == sportLeagueLevelId).ToListAsync();
    }
}
