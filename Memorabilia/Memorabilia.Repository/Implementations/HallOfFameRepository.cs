using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class HallOfFameRepository : DomainRepository<HallOfFame>, IHallOfFameRepository
{
    public HallOfFameRepository(DomainContext context) : base(context) { }

    public async Task<IEnumerable<HallOfFame>> GetAll(int? sportLeagueLevelId = null, int? inductionYear = null)
    {
        return await Items.Where(hof => (sportLeagueLevelId == null || hof.SportLeagueLevelId == sportLeagueLevelId)
                                     && (inductionYear == null || hof.InductionYear == inductionYear))
                          .ToListAsync();
    }
}
