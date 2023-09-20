namespace Memorabilia.Repository.Implementations;

public class ForumEntryImageRepository
    : DomainRepository<Entity.ForumEntryImage>, IForumEntryImageRepository
{
    public ForumEntryImageRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }
}