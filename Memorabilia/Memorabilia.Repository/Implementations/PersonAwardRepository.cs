using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class PersonAwardRepository : DomainRepository<PersonAward>, IPersonAwardRepository
{
    public PersonAwardRepository(DomainContext context) : base(context) { }

    private IQueryable<PersonAward> PersonAward => Items.Include(personAward => personAward.Person);

    public async Task<IEnumerable<PersonAward>> GetAll(int awardTypeId)
    {
        return await PersonAward.Where(personAward => personAward.AwardTypeId == awardTypeId)
                                .AsNoTracking()
                                .ToListAsync();
    }
}
