namespace Memorabilia.Repository.Implementations;

public class UserMessageRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<UserMessage>(context, memoryCache), IUserMessageRepository
{
    public async Task<PagedResult<UserMessage>> GetAllReceived(PageInfo pageInfo, 
                                                               int userId, 
                                                               int? userMessageStatusId = null)
    {
        var query =
            from userMessage in Context.UserMessage
            join userMessageReply in Context.UserMessageReply on userMessage.Id equals userMessageReply.UserMessageId
            where userMessageReply.ReceiverUserId == userId
               && (userMessageStatusId == null || userMessageReply.UserMessageStatusId == userMessageStatusId)
            orderby userMessageReply.CreatedDate descending
            group new { }
            by new
            {
                userMessage.Id,
                userMessage.Subject,
                userMessage.UserMessageStatusId
            } into groupedList
            select new UserMessage
            (
                groupedList.Key.Id,
                groupedList.Key.Subject,
                groupedList.Key.UserMessageStatusId
            );

        PagedResult<UserMessage> result
            = await query.ToPagedResult(pageInfo);

        int[] userMessageIds
            = result.Data
                    .Select(userMessage => userMessage.Id)
                    .OrderByDescending(id => id)
                    .ToArray();

        return new PagedResult<UserMessage>
        {
            Data = Items.Where(userMessage => userMessageIds.Contains(userMessage.Id)).ToArray(),
            PageInfo = result.PageInfo
        };
    }

    public async Task<PagedResult<UserMessage>> GetAllSent(PageInfo pageInfo, 
                                                           int userId, 
                                                           int? userMessageStatusId = null)
    {
        var query =
            from userMessage in Context.UserMessage
            join userMessageReply in Context.UserMessageReply on userMessage.Id equals userMessageReply.UserMessageId
            where userMessageReply.CreatedByUserId == userId
               && (userMessageStatusId == null || userMessageReply.UserMessageStatusId == userMessageStatusId)
            orderby userMessageReply.CreatedDate descending
            group new { }
            by new
            {
                userMessage.Id,
                userMessage.Subject,
                userMessage.UserMessageStatusId
            } into groupedList
            select new UserMessage
            (
                groupedList.Key.Id,
                groupedList.Key.Subject,
                groupedList.Key.UserMessageStatusId
            );

        PagedResult<UserMessage> result 
            = await query.ToPagedResult(pageInfo);

        int[] userMessageIds 
            = result.Data
                    .Select(userMessage => userMessage.Id)
                    .OrderByDescending(id => id)
                    .ToArray();

        return new PagedResult<UserMessage> { Data = Items.Where(userMessage => userMessageIds.Contains(userMessage.Id)).ToArray(),
                                              PageInfo = result.PageInfo };
    }

    public async Task<PagedResult<UserMessage>> SearchReceived(PageInfo pageInfo, 
                                                               string searchText, 
                                                               int userId)
    {
        var query =
            from userMessage in Context.UserMessage
            join userMessageReply in Context.UserMessageReply on userMessage.Id equals userMessageReply.UserMessageId
            where userMessageReply.ReceiverUserId == userId
               && (userMessage.Subject.Contains(searchText)
                   || userMessageReply.Message.Contains(searchText))
            orderby userMessageReply.CreatedDate descending
            group new { }
            by new
            {
                userMessage.Id,
                userMessage.Subject,
                userMessage.UserMessageStatusId
            } into groupedList
            select new UserMessage
            (
                groupedList.Key.Id,
                groupedList.Key.Subject,
                groupedList.Key.UserMessageStatusId
            );

        PagedResult<UserMessage> result
            = await query.ToPagedResult(pageInfo);

        int[] userMessageIds
            = result.Data
                    .Select(userMessage => userMessage.Id)
                    .OrderByDescending(id => id)
                    .ToArray();

        return new PagedResult<UserMessage>
        {
            Data = Items.Where(userMessage => userMessageIds.Contains(userMessage.Id)).ToArray(),
            PageInfo = result.PageInfo
        };
    }

    public async Task<PagedResult<UserMessage>> SearchSent(PageInfo pageInfo, 
                                                           string searchText, 
                                                           int userId)
    {
        var query =
            from userMessage in Context.UserMessage
            join userMessageReply in Context.UserMessageReply on userMessage.Id equals userMessageReply.UserMessageId
            where userMessageReply.CreatedByUserId == userId
               && (userMessage.Subject.Contains(searchText)
                   || userMessageReply.Message.Contains(searchText))
            orderby userMessageReply.CreatedDate descending
            group new { }
            by new
            {
                userMessage.Id,
                userMessage.Subject,
                userMessage.UserMessageStatusId
            } into groupedList
            select new UserMessage
            (
                groupedList.Key.Id,
                groupedList.Key.Subject,
                groupedList.Key.UserMessageStatusId
            );

        PagedResult<UserMessage> result
            = await query.ToPagedResult(pageInfo);

        int[] userMessageIds
            = result.Data
                    .Select(userMessage => userMessage.Id)
                    .OrderByDescending(id => id)
                    .ToArray();

        return new PagedResult<UserMessage>
        {
            Data = Items.Where(userMessage => userMessageIds.Contains(userMessage.Id)).ToArray(),
            PageInfo = result.PageInfo
        };
    }
}
