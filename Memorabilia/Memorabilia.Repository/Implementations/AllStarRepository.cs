﻿namespace Memorabilia.Repository.Implementations;

public class AllStarRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<AllStar>(context, memoryCache), IAllStarRepository
{
    private IQueryable<AllStar> AllStars 
        => Items.Include(allStar => allStar.Person);

    public async Task<IEnumerable<AllStar>> GetAll(int year, Constant.Sport sport = null)
        => (await AllStars.Where(allStar => allStar.Year == year && (sport == null || allStar.SportId == sport.Id))
                          .AsNoTracking()
                          .ToArrayAsync())
                  .OrderByDescending(allStar => allStar.Person.DisplayName);
}
