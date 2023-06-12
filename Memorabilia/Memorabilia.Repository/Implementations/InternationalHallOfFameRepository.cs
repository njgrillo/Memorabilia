namespace Memorabilia.Repository.Implementations;

public class InternationalHallOfFameRepository 
    : DomainRepository<Entity.InternationalHallOfFame>, IInternationalHallOfFameRepository
{
    public InternationalHallOfFameRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.InternationalHallOfFame> InternationalHallOfFames 
        => Items.Include(hallOfFame => hallOfFame.Person);

    public async Task<IEnumerable<Entity.InternationalHallOfFame>> GetAll(int? internationalHallOfFameTypeId = null, 
                                                                          int? sportId = null)
        => (await InternationalHallOfFames.Where(hallOfFame => (internationalHallOfFameTypeId == null || hallOfFame.InternationalHallOfFameTypeId == internationalHallOfFameTypeId)
                                                                && (sportId == null || hallOfFame.Person.Sports.Single(sport => sport.IsPrimary).SportId == sportId))
                                          .AsNoTracking()
                                          .ToListAsync())
                    .OrderByDescending(hallOfFame => hallOfFame.Person.DisplayName);
}

