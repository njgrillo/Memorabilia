namespace Memorabilia.Repository.Implementations;

public class MountRushmoreRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<MountRushmore>(context, memoryCache), IMountRushmoreRepository
{
    private IQueryable<MountRushmore> MountRushmore
        => Items.Include(mountRushmore => mountRushmore.People);

    public override async Task<MountRushmore> Get(int id)
        => await MountRushmore.SingleOrDefaultAsync(mountRushmore => mountRushmore.Id == id);

    public async Task<PagedResult<MountRushmore>> GetAll(int userId, PageInfo pageInfo, string filter = null)
        => await Items.Where(mountRushmore => mountRushmore.UserId == userId &&
                                              (filter.IsNullOrEmpty() ||
                                               mountRushmore.People.Any(person => EF.Functions.Like(person.Person.LegalName, filter) || EF.Functions.Like(person.Person.Name, filter)) ||
                                               EF.Functions.Like(mountRushmore.Name, filter) ||
                                               EF.Functions.Like(mountRushmore.Description, filter)))
                      .ToPagedResult(pageInfo);

    public async Task<PagedResult<MountRushmore>> GetAllPublic(PageInfo pageInfo)
        => await Items.Where(mountRushmore => mountRushmore.PrivacyTypeId == Constant.PrivacyType.Public.Id)
                      .ToPagedResult(pageInfo);
}
