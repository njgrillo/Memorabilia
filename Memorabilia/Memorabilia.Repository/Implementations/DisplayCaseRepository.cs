namespace Memorabilia.Repository.Implementations;

public class DisplayCaseRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<DisplayCase>(context, memoryCache), IDisplayCaseRepository
{
    private IQueryable<DisplayCase> DisplayCase
        => Items.Include(DisplayCase => DisplayCase.Memorabilias);

    public override async Task<DisplayCase> Get(int id)
        => await DisplayCase.SingleOrDefaultAsync(displayCase => displayCase.Id == id);

    public async Task<PagedResult<DisplayCase>> GetAll(int userId, PageInfo pageInfo)
        => await Items.Where(displayCase => displayCase.UserId == userId)
                      .ToPagedResult(pageInfo);

    public async Task<PagedResult<DisplayCase>> GetAllPublic(PageInfo pageInfo)
        => await Items.Where(displayCase => displayCase.PrivacyTypeId == Constant.PrivacyType.Public.Id)
                      .ToPagedResult(pageInfo);
}
