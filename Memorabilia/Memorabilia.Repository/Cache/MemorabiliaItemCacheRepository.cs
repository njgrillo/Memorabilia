namespace Memorabilia.Repository.Cache;

public class MemorabiliaItemCacheRepository : MemorabiliaCacheRepository<Domain.Entities.Memorabilia>, IMemorabiliaItemRepository
{
    private readonly MemorabiliaItemRepository _memorabiliaItemRepository;

    public MemorabiliaItemCacheRepository(MemorabiliaContext context, MemorabiliaItemRepository memorabiliaItemRepository, IMemoryCache memoryCache) 
        : base(context, memoryCache) 
    { 
        _memorabiliaItemRepository = memorabiliaItemRepository; 
    }

    public Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId)
    {
        return GetAll($"MemorabiliaItem_GetAll_{userId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _memorabiliaItemRepository.GetAll(userId);
        });
    }

    public Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId)
    {
        throw new NotImplementedException();
    }
}
