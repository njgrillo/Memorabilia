namespace Memorabilia.Repository.Implementations;

public class ThroughTheMailRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<ThroughTheMail>(context, memoryCache), IThroughTheMailRepository
{
    private IQueryable<ThroughTheMail> ThroughTheMail
        => Items.Include(throughTheMail => throughTheMail.Address)
                .Include(throughTheMail => throughTheMail.Memorabilia)
                .Include(throughTheMail => throughTheMail.Person);

    public override async Task<ThroughTheMail> Get(int id)
        => await Items.SingleOrDefaultAsync(throughTheMail => throughTheMail.Id == id);

    public async Task<Address[]> GetAddresses(int personId)
    {
        IQueryable<Address> query =
            from throughTheMail in Context.ThroughTheMail
            join address in Context.Address on throughTheMail.AddressId equals address.Id
            where throughTheMail.PersonId == personId
            select address;

        Address[] addresses = await query.ToArrayAsync();

        return addresses.DistinctBy(address => address.SingleLine)
                        .ToArray();
    }

    public async Task<ThroughTheMail[]> GetAll(int userId, int[] throughTheMailIds = null)
        => await ThroughTheMail.Where(throughTheMail => throughTheMail.UserId == userId 
                                                     && (throughTheMailIds == null || throughTheMailIds.Contains(throughTheMail.Id)))
                               .ToArrayAsync();

    public async Task<PagedResult<ThroughTheMail>> GetAllReceived(PageInfo pageInfo, int userId)
    {
        int[] throughTheMailIds
            = await ThroughTheMail.Where(throughTheMail => throughTheMail.UserId == userId
                                                        && throughTheMail.Memorabilia.Any(item => item.AutographId != null))
                                  .Select(throughTheMail => throughTheMail.Id)
                                  .Distinct()
                                  .ToArrayAsync();

        var query =
            from throughTheMail in Context.ThroughTheMail.Include(throughTheMail => throughTheMail.Memorabilia)
            where throughTheMailIds.Contains(throughTheMail.Id)
            orderby throughTheMail.ReceivedDate descending
            select new ThroughTheMail(throughTheMail);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<int> GetAllReceivedCount(int userId)
        => await ThroughTheMail.Where(throughTheMail => throughTheMail.UserId == userId
                                                     && throughTheMail.Memorabilia.Any(item => item.AutographId != null))
                               .Select(throughTheMail => throughTheMail.Id)
                               .Distinct()
                               .CountAsync();

    public async Task<PagedResult<ThroughTheMail>> GetAllSent(PageInfo pageInfo, int userId)
    {
        int[] throughTheMailIds
            = await ThroughTheMail.Where(throughTheMail => throughTheMail.UserId == userId
                                                        && throughTheMail.ReceivedDate == null
                                                        && throughTheMail.Memorabilia.All(item => item.AutographId == null))
                                  .Select(throughTheMail => throughTheMail.Id)
                                  .Distinct()
                                  .ToArrayAsync();

        var query =
            from throughTheMail in Context.ThroughTheMail
            where throughTheMailIds.Contains(throughTheMail.Id)
            orderby throughTheMail.SentDate descending
            select new ThroughTheMail(throughTheMail);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<int> GetAllSentCount(int userId)
        => await ThroughTheMail.Where(throughTheMail => throughTheMail.UserId == userId
                                                     && throughTheMail.ReceivedDate == null
                                                     && throughTheMail.Memorabilia.All(item => item.AutographId == null))
                               .Select(throughTheMail => throughTheMail.Id)
                               .Distinct()
                               .CountAsync();
}
