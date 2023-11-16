namespace Memorabilia.Repository.Implementations;

public class InternationalHallOfFameRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<InternationalHallOfFame>(context, memoryCache), IInternationalHallOfFameRepository
{
    private IQueryable<InternationalHallOfFame> InternationalHallOfFames 
        => Items.Include(hallOfFame => hallOfFame.Person);

    public async Task<IEnumerable<InternationalHallOfFame>> GetAll(int? internationalHallOfFameTypeId = null, 
                                                                          int? sportId = null)
        => (await InternationalHallOfFames.Where(hallOfFame => (internationalHallOfFameTypeId == null || hallOfFame.InternationalHallOfFameTypeId == internationalHallOfFameTypeId)
                                                            && (sportId == null || hallOfFame.Person.Sports.Single(sport => sport.IsPrimary).SportId == sportId))
                                          .AsNoTracking()
                                          .ToListAsync())
                    .OrderByDescending(hallOfFame => hallOfFame.Person.DisplayName);
}

