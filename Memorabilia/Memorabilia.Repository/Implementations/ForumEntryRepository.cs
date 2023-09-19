namespace Memorabilia.Repository.Implementations;

public class ForumEntryRepository
    : DomainRepository<Entity.ForumEntry>, IForumEntryRepository
{
    public ForumEntryRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }    
}
