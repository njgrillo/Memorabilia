namespace Memorabilia.Repository.Cache;

public class MemorabiliaItemCacheRepository : MemorabiliaRepository<Domain.Entities.Memorabilia>, IMemorabiliaItemRepository
{
    private readonly MemorabiliaItemRepository _memorabiliaItemRepository;

    public MemorabiliaItemCacheRepository(MemorabiliaContext context, MemorabiliaItemRepository memorabiliaItemRepository, IMemoryCache memoryCache) 
        : base(context, memoryCache) 
    { 
        _memorabiliaItemRepository = memorabiliaItemRepository; 
    }

    public override async Task Add(Domain.Entities.Memorabilia item, CancellationToken cancellationToken = default)
    {
        RemoveFromCache($"MemorabiliaItem_GetAll_{item.UserId}");

        await _memorabiliaItemRepository.Add(item, cancellationToken);
    }

    public Task<IEnumerable<Domain.Entities.Memorabilia>> GetAll(int userId)
    {
        return GetFromCache($"MemorabiliaItem_GetAll_{userId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _memorabiliaItemRepository.GetAll(userId);
        });
    }

    public Task<IEnumerable<Domain.Entities.Memorabilia>> GetAllUnsigned(int userId)
    {
        return GetFromCache($"MemorabiliaItem_GetAllUnsigned_{userId}", entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromDays(1));
            return _memorabiliaItemRepository.GetAllUnsigned(userId);
        });
    }
}
