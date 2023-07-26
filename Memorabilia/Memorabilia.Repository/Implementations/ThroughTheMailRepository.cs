namespace Memorabilia.Repository.Implementations;

public class ThroughTheMailRepository
    : MemorabiliaRepository<Entity.ThroughTheMail>, IThroughTheMailRepository
{
    public ThroughTheMailRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<Entity.ThroughTheMail> ThroughTheMail
        => Items.Include(throughTheMail => throughTheMail.Memorabilia)
                .Include(throughTheMail => throughTheMail.Person);

    public override async Task<Entity.ThroughTheMail> Get(int id)
        => await Items.SingleOrDefaultAsync(throughTheMail => throughTheMail.Id == id);

    public async Task<Entity.ThroughTheMail[]> GetAll(int userId)
        => await ThroughTheMail.Where(throughTheMail => throughTheMail.UserId == userId)
                               .ToArrayAsync();
}
