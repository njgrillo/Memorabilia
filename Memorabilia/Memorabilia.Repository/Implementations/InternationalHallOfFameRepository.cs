using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class InternationalHallOfFameRepository : DomainRepository<InternationalHallOfFame>, IInternationalHallOfFameRepository
{
    public InternationalHallOfFameRepository(DomainContext context) : base(context) { }

    private IQueryable<InternationalHallOfFame> InternationalHallOfFames => Items.Include(hallOfFame => hallOfFame.Person);

    public async Task<IEnumerable<InternationalHallOfFame>> GetAll(int? internationalHallOfFameTypeId = null, int? sportLeagueLevelId = null)
    {
        return (await InternationalHallOfFames.Where(hallOfFame => (internationalHallOfFameTypeId == null || hallOfFame.InternationalHallOfFameTypeId == internationalHallOfFameTypeId)
                                                                && (sportLeagueLevelId == null || hallOfFame.Person.Teams.Select(team => team.Team.Franchise.SportLeagueLevelId).Contains(sportLeagueLevelId.Value))).ToListAsync())
                                              .OrderByDescending(hallOfFame => hallOfFame.Person.DisplayName);
    }
}
