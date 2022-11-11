using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Implementations;

public class AutographImageRepository : MemorabiliaRepository<AutographImage>, IDomainRepository<AutographImage>
{
    public AutographImageRepository(MemorabiliaContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }
}
