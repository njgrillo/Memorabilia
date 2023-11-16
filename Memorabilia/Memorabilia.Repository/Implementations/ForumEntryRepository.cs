namespace Memorabilia.Repository.Implementations;

public class ForumEntryRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<ForumEntry>(context, memoryCache), IForumEntryRepository
{
}
