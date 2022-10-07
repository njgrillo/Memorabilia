using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class HallOfFameRepository : DomainRepository<HallOfFame>, IHallOfFameRepository
{
    public HallOfFameRepository(DomainContext context) : base(context) { }

    public async Task<IEnumerable<HallOfFame>> GetAll(int? personId = null)
    {
        return personId.HasValue
            ? await Items.Where(hof => hof.PersonId == personId).ToListAsync()
            : await Items.ToListAsync();
    }
}
