using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class DraftRepository : DomainRepository<Draft>, IDraftRepository
{
    public DraftRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Draft> Drafts => Items.Include(draft => draft.Franchise)
                                             .Include(draft => draft.Person);

    public async Task<IEnumerable<Draft>> GetAll(int franchiseId)
    {
        return await Drafts.Where(draft => draft.FranchiseId == franchiseId)
                           .AsNoTracking()
                           .ToListAsync();
    }
}
