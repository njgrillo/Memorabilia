namespace Memorabilia.Repository.Implementations;

public class ForumEntryImageRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ForumEntryImage>(context, memoryCache), IForumEntryImageRepository
{
}