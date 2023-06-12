namespace Memorabilia.Repository.Implementations;

public class DraftRepository 
    : DomainRepository<Entity.Draft>, IDraftRepository
{
    public DraftRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.Draft> Drafts 
        => Items.Include(draft => draft.Franchise)
                .Include(draft => draft.Person);

    public async Task<IEnumerable<Entity.Draft>> GetAll(int franchiseId)
        => await Drafts.Where(draft => draft.FranchiseId == franchiseId)
                       .AsNoTracking()
                       .ToListAsync();
}
