namespace Memorabilia.Repository.Implementations;

public class PersonAwardRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<PersonAward>(context, memoryCache), IPersonAwardRepository
{
    private IQueryable<PersonAward> PersonAward 
        => Items.Include(personAward => personAward.Person);

    public async Task<IEnumerable<PersonAward>> GetAll(int awardTypeId)
        => await PersonAward.Where(personAward => personAward.AwardTypeId == awardTypeId)
                            .AsNoTracking()
                            .ToListAsync();
}
