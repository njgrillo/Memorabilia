using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class HallOfFameRepository : DomainRepository<HallOfFame>, IHallOfFameRepository
{
    public HallOfFameRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<HallOfFame> HallOfFames => Items.Include(hallOfFame => hallOfFame.Person);

    public async Task<IEnumerable<HallOfFame>> GetAll(int? sportLeagueLevelId = null, int? inductionYear = null)
    {
        return await HallOfFames.Where(hof => (sportLeagueLevelId == null || hof.SportLeagueLevelId == sportLeagueLevelId)
                                              && (inductionYear == null || hof.InductionYear == inductionYear))
                                .AsNoTracking()
                                .ToListAsync();
    }
}
