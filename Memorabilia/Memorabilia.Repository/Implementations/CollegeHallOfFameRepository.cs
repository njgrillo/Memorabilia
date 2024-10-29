namespace Memorabilia.Repository.Implementations;

public class CollegeHallOfFameRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<CollegeHallOfFame>(context, memoryCache), ICollegeHallOfFameRepository
{
    private IQueryable<CollegeHallOfFame> CollegeHallOfFames
        => Items.Include(hallOfFame => hallOfFame.Person);

    public async Task<CollegeHallOfFame[]> GetAll(int collegeId)
        => (await CollegeHallOfFames.Where(hallOfFame => hallOfFame.CollegeId == collegeId)
                                    .OrderByDescending(hallOfFame => hallOfFame.Person.DisplayName)
                                    .AsNoTracking()
                                    .ToArrayAsync());
}
