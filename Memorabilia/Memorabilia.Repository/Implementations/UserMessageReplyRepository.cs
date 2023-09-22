namespace Memorabilia.Repository.Implementations;

public class UserMessageReplyRepository
    : DomainRepository<Entity.UserMessageReply>, IUserMessageReplyRepository
{
    public UserMessageReplyRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }
}
