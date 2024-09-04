namespace Memorabilia.Repository.Implementations;

public class MountRushmoreRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<MountRushmore>(context, memoryCache), IMountRushmoreRepository
{
    private IQueryable<MountRushmore> MountRushmore
        => Items.Include(mountRushmore => mountRushmore.People);

    public override async Task<MountRushmore> Get(int id)
        => await MountRushmore.SingleOrDefaultAsync(mountRushmore => mountRushmore.Id == id);

    public async Task<MountRushmore[]> GetAll(int userId)
        => await Items.Where(mountRushmore => mountRushmore.UserId == userId)
                      .ToArrayAsync();

    public async Task<MountRushmore[]> GetAllPublic()
        => await Items.Where(mountRushmore => mountRushmore.PrivacyTypeId == Constant.PrivacyType.Public.Id)
                      .ToArrayAsync();
}
