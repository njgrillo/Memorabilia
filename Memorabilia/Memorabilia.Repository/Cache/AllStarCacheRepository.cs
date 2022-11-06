using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Cache;

public class AllStarCacheRepository : DomainCacheRepository<AllStar>, IAllStarRepository
{
    private readonly AllStarRepository _allStarRepository;

    public AllStarCacheRepository(DomainContext context, AllStarRepository allStarRepository, IMemoryCache memoryCache)
        : base(context, memoryCache)
    {
        _allStarRepository = allStarRepository;
    }

    public Task<IEnumerable<AllStar>> GetAll(int year)
    {
        return GetAll($"AllStar_GetAll_{year}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _allStarRepository.GetAll(year);
        });
    }
}
