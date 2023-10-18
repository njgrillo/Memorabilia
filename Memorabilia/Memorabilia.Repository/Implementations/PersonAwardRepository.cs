namespace Memorabilia.Repository.Implementations;

public class PersonAwardRepository 
    : DomainRepository<PersonAward>, IPersonAwardRepository
{
    public PersonAwardRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<PersonAward> PersonAward 
        => Items.Include(personAward => personAward.Person);

    public async Task<IEnumerable<PersonAward>> GetAll(int awardTypeId)
        => await PersonAward.Where(personAward => personAward.AwardTypeId == awardTypeId)
                            .AsNoTracking()
                            .ToListAsync();
}
