﻿namespace Memorabilia.Repository.Implementations;

public class HallOfFameRepository 
    : DomainRepository<Entity.HallOfFame>, IHallOfFameRepository
{
    public HallOfFameRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.HallOfFame> HallOfFames 
        => Items.Include(hallOfFame => hallOfFame.Person);

    public async Task<IEnumerable<Entity.HallOfFame>> GetAll(int? sportLeagueLevelId = null, 
                                                             int? inductionYear = null)
        => await HallOfFames.Where(hof => (sportLeagueLevelId == null || hof.SportLeagueLevelId == sportLeagueLevelId)
                                           && (inductionYear == null || hof.InductionYear == inductionYear))
                            .AsNoTracking()
                            .ToListAsync();
}
