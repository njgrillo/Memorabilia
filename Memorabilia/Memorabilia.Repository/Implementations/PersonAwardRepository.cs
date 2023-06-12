namespace Memorabilia.Repository.Implementations;

public class PersonAwardRepository 
    : DomainRepository<Entity.PersonAward>, IPersonAwardRepository
{
    public PersonAwardRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.PersonAward> PersonAward 
        => Items.Include(personAward => personAward.Person);

    public async Task<IEnumerable<Entity.PersonAward>> GetAll(int awardTypeId)
        => await PersonAward.Where(personAward => personAward.AwardTypeId == awardTypeId)
                            .AsNoTracking()
                            .ToListAsync();
}
