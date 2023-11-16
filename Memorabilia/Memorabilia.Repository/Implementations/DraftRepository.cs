namespace Memorabilia.Repository.Implementations;

public class DraftRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<Draft>(context, memoryCache), IDraftRepository
{
    private IQueryable<Draft> Drafts 
        => Items.Include(draft => draft.Franchise)
                .Include(draft => draft.Person);

    public async Task<IEnumerable<Draft>> GetAll(int franchiseId)
        => await Drafts.Where(draft => draft.FranchiseId == franchiseId)
                       .AsNoTracking()
                       .ToListAsync();
}
