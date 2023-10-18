namespace Memorabilia.Repository.Implementations;

public class ForumEntryImageRepository
    : DomainRepository<ForumEntryImage>, IForumEntryImageRepository
{
    public ForumEntryImageRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }
}