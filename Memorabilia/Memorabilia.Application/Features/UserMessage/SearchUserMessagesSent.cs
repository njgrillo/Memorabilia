namespace Memorabilia.Application.Features.UserMessage;

public record SearchUserMessagesSent(PageInfo PageInfo, string SearchText)
    : IQuery<UserMessagesModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         IUserMessageRepository userMessageRepository) 
        : QueryHandler<SearchUserMessagesSent, UserMessagesModel>
    {
        protected override async Task<UserMessagesModel> Handle(SearchUserMessagesSent query)
        {
            PagedResult<Entity.UserMessage> result
                = await userMessageRepository.SearchSent(query.PageInfo, 
                                                         query.SearchText, 
                                                         applicationStateService.CurrentUser.Id);

            return new UserMessagesModel(result.Data, result.PageInfo);
        }
    }
}
