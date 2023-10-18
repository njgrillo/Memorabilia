namespace Memorabilia.Repository.Implementations;

public class ThroughTheMailRepository
    : MemorabiliaRepository<ThroughTheMail>, IThroughTheMailRepository
{
    public ThroughTheMailRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    private IQueryable<ThroughTheMail> ThroughTheMail
        => Items.Include(throughTheMail => throughTheMail.Memorabilia)
                .Include(throughTheMail => throughTheMail.Person);

    public override async Task<ThroughTheMail> Get(int id)
        => await Items.SingleOrDefaultAsync(throughTheMail => throughTheMail.Id == id);

    public async Task<ThroughTheMail[]> GetAll(int userId, int[] throughTheMailIds = null)
        => await ThroughTheMail.Where(throughTheMail => throughTheMail.UserId == userId 
                                                     && (throughTheMailIds == null || throughTheMailIds.Contains(throughTheMail.Id)))
                               .ToArrayAsync();
}
