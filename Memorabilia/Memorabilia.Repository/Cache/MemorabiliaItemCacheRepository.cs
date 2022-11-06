namespace Memorabilia.Repository.Cache;

public class MemorabiliaItemCacheRepository : MemorabiliaCacheRepository<Domain.Entities.Memorabilia>, IMemorabiliaItemRepository
{
    private readonly IMemorabiliaItemRepository _memorabiliaItemRepository;

    public MemorabiliaItemCacheRepository(MemorabiliaContext context, IMemorabiliaItemRepository memorabiliaItemRepository, IMemoryCache memoryCache) 
        : base(context, memoryCache) 
    { 
        _memorabiliaItemRepository = memorabiliaItemRepository; 
    }

    public Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId)
    {
        return GetAll($"MemorabiliaItem_GetAll_{userId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _memorabiliaItemRepository.GetAll();
        });
    }

    public Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId)
    {
        throw new NotImplementedException();
    }
}
