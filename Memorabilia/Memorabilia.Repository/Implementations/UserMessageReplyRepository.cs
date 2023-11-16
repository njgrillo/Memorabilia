namespace Memorabilia.Repository.Implementations;

public class UserMessageReplyRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<UserMessageReply>(context, memoryCache), IUserMessageReplyRepository
{
}
