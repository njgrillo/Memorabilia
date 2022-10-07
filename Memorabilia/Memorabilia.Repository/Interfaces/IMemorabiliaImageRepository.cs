using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces;

public interface IMemorabiliaImageRepository : IDomainRepository<MemorabiliaImage>
{
    Task<List<MemorabiliaImage>> GetAll(int memorabiliaId);
}
