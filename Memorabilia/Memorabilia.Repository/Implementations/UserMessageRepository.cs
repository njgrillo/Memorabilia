namespace Memorabilia.Repository.Implementations;

public class UserMessageRepository
    : DomainRepository<Entity.UserMessage>, IUserMessageRepository
{
    public UserMessageRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<PagedResult<Entity.UserMessage>> GetAll(PageInfo pageInfo, int userId, int? userMessageStatusId = null)
    {
        var query =
            from userMessage in Context.UserMessage
            join userMessageReply in Context.UserMessageReply on userMessage.Id equals userMessageReply.UserMessageId
            join user in Context.User on userMessage.CreatedByUserId equals user.Id
            where userMessage.CreatedByUserId == userId
               && (userMessageStatusId == null || userMessageReply.UserMessageStatusId == userMessageStatusId)
            orderby userMessage.CreatedDate descending
            group new { }
            by new
            {
                userMessage.Id,
                userMessage.Subject,
                userMessage.SenderUserId,
                userMessage.ReceiverUserId,
                userMessage.CreatedDate,
                userMessage.CreatedByUserId,
            } into groupedList
            select new Entity.UserMessage
            (
                groupedList.Key.CreatedByUserId,
                groupedList.Key.CreatedDate,
                groupedList.Key.Id,
                groupedList.Key.ReceiverUserId,
                groupedList.Key.SenderUserId,
                groupedList.Key.Subject
            );

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<PagedResult<Entity.UserMessage>> Search(PageInfo pageInfo, string searchText, int userId)
    {
        var query =
            from userMessage in Context.UserMessage
            join userMessageReply in Context.UserMessageReply on userMessage.Id equals userMessageReply.UserMessageId
            join user in Context.User on userMessage.CreatedByUserId equals user.Id
            where userMessage.CreatedByUserId == userId
               && (userMessage.Subject.Contains(searchText)
                   || userMessageReply.Message.Contains(searchText))
            orderby userMessage.CreatedDate descending
            group new { }
            by new
            {
                userMessage.Id,
                userMessage.Subject,
                userMessage.SenderUserId,
                userMessage.ReceiverUserId,
                userMessage.CreatedDate,
                userMessage.CreatedByUserId,
            } into groupedList
            select new Entity.UserMessage
            (
                groupedList.Key.CreatedByUserId,
                groupedList.Key.CreatedDate,
                groupedList.Key.Id,
                groupedList.Key.ReceiverUserId,
                groupedList.Key.SenderUserId,
                groupedList.Key.Subject
            );

        return await query.ToPagedResult(pageInfo);
    }
}
