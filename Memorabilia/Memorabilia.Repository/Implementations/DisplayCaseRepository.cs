namespace Memorabilia.Repository.Implementations;

public class DisplayCaseRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<DisplayCase>(context, memoryCache), IDisplayCaseRepository
{
    private IQueryable<DisplayCase> DisplayCase
        => Items.Include(DisplayCase => DisplayCase.Memorabilias);

    public override async Task<DisplayCase> Get(int id)
        => await DisplayCase.SingleOrDefaultAsync(displayCase => displayCase.Id == id);

    public async Task<DisplayCase[]> GetAll(int userId)
        => await Items.Where(displayCase => displayCase.UserId == userId)
                      .ToArrayAsync();

    public async Task<DisplayCase[]> GetAllPublic()
        => await Items.Where(displayCase => displayCase.PrivacyTypeId == Constant.PrivacyType.Public.Id)
                      .ToArrayAsync();
}
