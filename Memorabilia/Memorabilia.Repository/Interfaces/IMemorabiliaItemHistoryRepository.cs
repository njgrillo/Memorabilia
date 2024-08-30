namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaItemHistoryRepository
    : IHistoryRepository<MemorabiliaHistory>
{
    Task<MemorabiliaHistory[]> GetAll(int userId);

    Task<MemorabiliaHistory[]> GetAll(int[] ids);

    Task<PagedResult<MemorabiliaHistory>> GetAll(
        int userId,                                                 
        PageInfo pageInfo);
}
