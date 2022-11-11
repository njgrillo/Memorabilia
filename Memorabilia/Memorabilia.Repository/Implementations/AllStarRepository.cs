using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class AllStarRepository : DomainRepository<AllStar>, IAllStarRepository
{
    public AllStarRepository(DomainContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

    private IQueryable<AllStar> AllStars => Items.Include(allStar => allStar.Person);

    public async Task<IEnumerable<AllStar>> GetAll(int year)
    {
        return (await AllStars.Where(allStar => allStar.Year == year)
                              .AsNoTracking()
                              .ToListAsync())                              
                     .OrderByDescending(allStar => allStar.Person.DisplayName); 
    }
}
