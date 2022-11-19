namespace Memorabilia.Repository.Implementations;

public class MemorabiliaItemRepository : MemorabiliaRepository<Domain.Entities.Memorabilia>, IMemorabiliaItemRepository
{
    public MemorabiliaItemRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<Domain.Entities.Memorabilia> Memorabilia => Items.Include(memorabilia => memorabilia.Autographs)
                                                                        .Include("Autographs.Acquisition")
                                                                        .Include("Autographs.Authentications")
                                                                        .Include("Autographs.Images")
                                                                        .Include("Autographs.Inscriptions")
                                                                        .Include("Autographs.Person")
                                                                        .Include("Autographs.Spot")
                                                                        .Include(memorabilia => memorabilia.Bammer)
                                                                        .Include(memorabilia => memorabilia.Baseball)
                                                                        .Include(memorabilia => memorabilia.Basketball)
                                                                        .Include(memorabilia => memorabilia.Bat)
                                                                        .Include(memorabilia => memorabilia.Bobblehead)
                                                                        .Include(memorabilia => memorabilia.Book)
                                                                        .Include(memorabilia => memorabilia.Brand)
                                                                        .Include(memorabilia => memorabilia.Card)
                                                                        .Include(memorabilia => memorabilia.Commissioner)
                                                                        .Include(memorabilia => memorabilia.Figure)
                                                                        .Include(memorabilia => memorabilia.FirstDayCover)
                                                                        .Include(memorabilia => memorabilia.Football)
                                                                        .Include(memorabilia => memorabilia.Game)
                                                                        .Include(memorabilia => memorabilia.Glove)
                                                                        .Include(memorabilia => memorabilia.Helmet)
                                                                        .Include(memorabilia => memorabilia.Images)
                                                                        .Include(memorabilia => memorabilia.Jersey)
                                                                        .Include(memorabilia => memorabilia.LevelType)
                                                                        .Include(memorabilia => memorabilia.Magazine)
                                                                        .Include(memorabilia => memorabilia.MemorabiliaAcquisition)
                                                                        .Include(memorabilia => memorabilia.MemorabiliaAcquisition.Acquisition)
                                                                        .Include(memorabilia => memorabilia.People)
                                                                        .Include(memorabilia => memorabilia.Picture)
                                                                        .Include(memorabilia => memorabilia.Size)
                                                                        .Include(memorabilia => memorabilia.Sports)
                                                                        .Include(memorabilia => memorabilia.Teams)
                                                                        .Include(memorabilia => memorabilia.User);

    public override async Task Add(Domain.Entities.Memorabilia item, CancellationToken cancellationToken = default)
    {
        await base.Add(item, cancellationToken);
    }

    public override async Task<Domain.Entities.Memorabilia> Get(int id)
    {
        return await Memorabilia.SingleOrDefaultAsync(memorabilia => memorabilia.Id == id);
    }

    public async Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId)
    {
        return await Memorabilia.Where(memorabilia => memorabilia.UserId == userId)
                                .ToListAsync();

        //var query =
        //    from memorabilia in Context.Memorabilia
        //    where memorabilia.UserId == userId
        //    select new Domain.Entities.Memorabilia(memorabilia);

        //return await query.ToListAsync();
    }

    public async Task<PagedResult<Domain.Entities.Memorabilia>> GetAll(
        int userId, 
        PageInfo pageInfo,
        Expression<Func<Domain.Entities.Memorabilia, bool>> filter = null)
    {
        Expression<Func<Domain.Entities.Memorabilia, bool>> expression = memorabilia => memorabilia.UserId == userId;

        Func<Domain.Entities.Memorabilia, bool> test = expression.Compile();

        if (filter != null)
            expression = expression.And(filter);

        var query =
            from memorabilia in Context.Memorabilia
            where memorabilia.UserId == userId
            select new Domain.Entities.Memorabilia(memorabilia);

        return await query.ToPagedResult(pageInfo);

        //return await Memorabilia.Where(expression)
        //                        .ToPagedResult(pageInfo);
    }

    public async Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId)
    {
        return await Memorabilia.Where(memorabilia => memorabilia.UserId == userId && !memorabilia.Autographs.Any()).ToListAsync();
    }
}
